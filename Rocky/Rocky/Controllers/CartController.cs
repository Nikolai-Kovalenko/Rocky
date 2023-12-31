﻿using Braintree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Rocky_DatAccess;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Models.ViewModels;
using Rocky_Utility;
using Rocky_Utility.BrainTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductRepository _prodRepo;
        private readonly IEmailSender _emailSender;
        private readonly IApplicationUserRepository _appUserRepo;
        private readonly IInquiryDetailRepository _inqDetailRepo;
        private readonly IInquiryHeaderRepository _inqHeaderRepo;
        private readonly IOrderDetailRepository _ordDetailRepo;
        private readonly IOrderHeaderRepository _ordHeaderRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IBrainTreeGate _brain;

        [BindProperty]
        public ProductUserVM ProductUserVM { get; set; }

        public CartController(IProductRepository prodRepo, IApplicationUserRepository appUserRepo,
            IInquiryDetailRepository inqDetailRepo, IInquiryHeaderRepository inqHeaderRepo,
            IWebHostEnvironment webHostEnvironment, IEmailSender emailSender,
            IOrderDetailRepository ordDetailRepo, IOrderHeaderRepository ordHeaderRepo, IBrainTreeGate brain)
        {
            _prodRepo           = prodRepo;
            _appUserRepo        = appUserRepo;
            _inqDetailRepo      = inqDetailRepo;
            _inqHeaderRepo      = inqHeaderRepo;
            _webHostEnvironment = webHostEnvironment;
            _emailSender        = emailSender;
            _ordHeaderRepo      = ordHeaderRepo;
            _ordDetailRepo      = ordDetailRepo;
            _brain              = brain;
        }

        public IActionResult Index()
        {
            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if(HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                // session exists 
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            List<int> productCart = shoppingCartsList.Select(i => i.ProductId).ToList();
            IEnumerable<Product> prodListTemp = _prodRepo.GetAll(u => productCart.Contains(u.Id));
            IList<Product> prodList = new List<Product>();

            foreach(var catrObj in shoppingCartsList) 
            { 
                Product prodTemp = prodListTemp.FirstOrDefault(u => u.Id == catrObj.ProductId);
                prodTemp.TempSqFt = catrObj.SqFt;
                prodList.Add(prodTemp);
            }   

            return View(prodList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost(IEnumerable<Product> ProdIst)
        {
            List<ShoppingCart> ShoppingCartList = new List<ShoppingCart>();
            foreach (Product prod in ProdIst)
            {
                ShoppingCartList.Add(new ShoppingCart { ProductId = prod.Id, SqFt = prod.TempSqFt });
            }

            HttpContext.Session.Set(WC.SessionCart, ShoppingCartList);

            return RedirectToAction(nameof(Summary));
        }
         
        public IActionResult Summary()
        {
            ApplicationUser applicationUser;

            if (User.IsInRole(WC.AdminRole))
            {
                if(HttpContext.Session.Get<int>(WC.SessionInquiryId) !=0 )
                {
                    // cart has  been loaded using inquiry

                    InquiryHeader inquiryHeader = _inqHeaderRepo.FirstOrDefault(u => u.Id == HttpContext.Session.Get<int>(WC.SessionInquiryId));
                    applicationUser = new ApplicationUser()
                    {
                        Email = inquiryHeader.Email,
                        FullName = inquiryHeader.FullName,
                        PhoneNumber = inquiryHeader.PhoneNumber
                    };
                }
                else
                {
                    applicationUser = new ApplicationUser();    
                }

                var gatway = _brain.GetGeteway();
                var clientToken = gatway.ClientToken.Generate();
                ViewBag.ClientToken = clientToken;
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                // var userId = User.FindFirstValue(ClaimTypes.Name);

                applicationUser = _appUserRepo.FirstOrDefault(u => u.Id == claim.Value);
            }

            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                // session exists 
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            List<int> productCart = shoppingCartsList.Select(i => i.ProductId).ToList();
            IEnumerable<Product> prodList = _prodRepo.GetAll(u => productCart.Contains(u.Id));

            ProductUserVM = new ProductUserVM()
            {
                ApplicationUser = applicationUser,
            };

            foreach (var cartObj in shoppingCartsList) 
            {
                Product prodTemp = _prodRepo.FirstOrDefault(u => u.Id == cartObj.ProductId);
                prodTemp.TempSqFt = cartObj.SqFt;
                ProductUserVM.ProductList.Add(prodTemp);
            }

            return View(ProductUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Summary))]
        public async Task<IActionResult> SummaryPost(IFormCollection collection, ProductUserVM ProductUserVM)
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(User.IsInRole(WC.AdminRole))
            {
                // we need to create an order 

/*
                var orderTotal = 0.0;
                foreach (Product prod in ProductUserVM.ProductList)
                {
                    orderTotal += prod.Price * prod.TempSqFt;
                }
*/


                OrderHeader orderHeader = new OrderHeader
                {
                    CreatedByUserId = claim.Value,
                    FinalOrderTotal = ProductUserVM.ProductList.Sum(x => x.TempSqFt * x.Price),
                    City = ProductUserVM.ApplicationUser.City,
                    StreetAddress = ProductUserVM.ApplicationUser.StreetAddress,
                    State = ProductUserVM.ApplicationUser.State,
                    PostalCode = ProductUserVM.ApplicationUser.PostalCode,
                    FullName = ProductUserVM.ApplicationUser.FullName,
                    Email = ProductUserVM.ApplicationUser.Email,
                    PhoneNumber = ProductUserVM.ApplicationUser.PhoneNumber,
                    OrderDate = DateTime.Now,
                    OrderStatus = WC.StatusPending
                };

                _ordHeaderRepo.Add(orderHeader);
                _ordHeaderRepo.Save();

                foreach (var prod in ProductUserVM.ProductList)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderHeaderId = orderHeader.Id,
                        PricePerSqFt = prod.Price,
                        Sqft = prod.TempSqFt,
                        ProductId = prod.Id
                    };
                    _ordDetailRepo.Add(orderDetail);
                }
                _ordDetailRepo.Save();

                string nonceFromTheClient = collection["payment_method_nonce"];

                var request = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(orderHeader.FinalOrderTotal),
                    PaymentMethodNonce = nonceFromTheClient,
                    OrderId = orderHeader.Id.ToString(),
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true
                    }
                };

                var gateway = _brain.GetGeteway();
                Result<Transaction> result = gateway.Transaction.Sale(request);

                if(result.Target.ProcessorResponseText == "Approved")
                {
                    orderHeader.TransactionId = result.Target.Id;
                    orderHeader.OrderStatus = WC.StatusApproved;
                }
                else
                {
                    orderHeader.OrderStatus = WC.StatusConcelled;
                }

                _ordHeaderRepo.Save();
                return RedirectToAction(nameof(InquiryConfirmation), new {id = orderHeader.Id});
            }
            else
            {
                // we need to create an inquiry

                var PathToTemplate = _webHostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString()
                + "templates" + Path.DirectorySeparatorChar.ToString()
                + "Inquiry.html";

                var subject = "New Inquiry";
                string HtmlBody = "";
                using (StreamReader sr = System.IO.File.OpenText(PathToTemplate))
                {
                    HtmlBody = sr.ReadToEnd();
                }

                // Name: { 0}
                // Email: { 1}
                // Phone: { 2}
                // Products: { 3 }

                StringBuilder ProductListSB = new StringBuilder();
                foreach (var prod in ProductUserVM.ProductList)
                {
                    ProductListSB.Append($" - Name: {prod.Name} <span style='fonr-size:14px;'> (ID: {prod.Id})</span><br />");
                }

                string messageBody = string.Format(HtmlBody,
                    ProductUserVM.ApplicationUser.FullName,
                    ProductUserVM.ApplicationUser.Email,
                    ProductUserVM.ApplicationUser.PhoneNumber,
                    ProductListSB.ToString());

                await _emailSender.SendEmailAsync(WC.EmailAdin, subject, messageBody);

                InquiryHeader inquiryHeader = new InquiryHeader()
                {
                    ApplicationUserId = claim.Value,
                    FullName = ProductUserVM.ApplicationUser.FullName,
                    Email = ProductUserVM.ApplicationUser.Email,
                    PhoneNumber = ProductUserVM.ApplicationUser.PhoneNumber,
                    InquiryDate = DateTime.Now
                };

                _inqHeaderRepo.Add(inquiryHeader);
                _inqHeaderRepo.Save();

                foreach (var prod in ProductUserVM.ProductList)
                {
                    InquiryDetail inquiryDetail = new InquiryDetail()
                    {
                        InquiryHeaderId = inquiryHeader.Id,
                        ProductId = prod.Id
                    };
                    _inqDetailRepo.Add(inquiryDetail);
                }
                _inqDetailRepo.Save();

                TempData[WC.Success] = "Inquiry submitted successfully";
            }


            return RedirectToAction(nameof(InquiryConfirmation));
        }

        public IActionResult InquiryConfirmation(int id=0)
        {
            OrderHeader orderHeader = _ordHeaderRepo.FirstOrDefault(u => u.Id == id);

            HttpContext.Session.Clear();
            return View(orderHeader);
        }

        public IActionResult Remove(int? id)
        {
            List<ShoppingCart> shoppingCartsList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                // session exists 
                shoppingCartsList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            shoppingCartsList.Remove(shoppingCartsList.FirstOrDefault(u => u.ProductId == id));

            HttpContext.Session.Set(WC.SessionCart, shoppingCartsList);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCart(IEnumerable<Product> ProdIst)
        {
            List<ShoppingCart> ShoppingCartList = new List<ShoppingCart>();
            foreach (Product prod in ProdIst) 
            { 
                ShoppingCartList.Add(new ShoppingCart { ProductId = prod.Id, SqFt = prod.TempSqFt });
            }

            HttpContext.Session.Set(WC.SessionCart, ShoppingCartList);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
