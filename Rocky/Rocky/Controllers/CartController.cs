﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Rocky_DatAccess;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Models.ViewModels;
using Rocky_Utility;
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
        private readonly IApplicationUserRepository _appUserRepo;
        private readonly IInquiryDetailRepository _inqDetailRepo;
        private readonly IInquiryHeaderRepository _inqHeaderRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public ProductUserVM ProductUserVM { get; set; }

        public CartController(IProductRepository prodRepo, IApplicationUserRepository appUserRepo,
            IInquiryDetailRepository inqDetailRepo, IInquiryHeaderRepository inqHeaderRepo,
            IWebHostEnvironment webHostEnvironment, IEmailSender emailSender)
        {
            _prodRepo           = prodRepo;
            _appUserRepo        = appUserRepo;
            _inqDetailRepo      = inqDetailRepo;
            _inqHeaderRepo      = inqHeaderRepo;
            _webHostEnvironment = webHostEnvironment;
            _emailSender        = emailSender;
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
            IEnumerable<Product> prodList = _prodRepo.GetAll(u => productCart.Contains(u.Id));

            return View(prodList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return RedirectToAction(nameof(Summary));
        }
         
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // var userId = User.FindFirstValue(ClaimTypes.Name);

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
                ApplicationUser = _appUserRepo.FirstOrDefault(u => u.Id == claim.Value),
                ProductList = prodList.ToList()
            };

            return View(ProductUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName(nameof(Summary))]
        public async Task<IActionResult> SummaryPost(ProductUserVM ProductUserVM)
        {
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
            foreach(var prod in ProductUserVM.ProductList) 
            {
                ProductListSB.Append($" - Name: {prod.Name} <span style='fonr-size:14px;'> (ID: {prod.Id})</span><br />");
            }

            string messageBody = string.Format(HtmlBody,
                ProductUserVM.ApplicationUser.FullName,
                ProductUserVM.ApplicationUser.Email,
                ProductUserVM.ApplicationUser.PhoneNumber,
                ProductListSB.ToString());

            await _emailSender.SendEmailAsync(WC.EmailAdin, subject, messageBody);

                return RedirectToAction(nameof(InquiryConfirmation));
        }

        public IActionResult InquiryConfirmation()
        {
            HttpContext.Session.Clear();
            return View();
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
    }
}
