using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky_DatAccess;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
using Rocky_Models.ViewModels;
using Rocky_Utility;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;

namespace Rocky.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class InquiryController : Controller 
    {
        public IInquiryHeaderRepository _inqHeaderRepo;
        public IInquiryDetailRepository _inqDetailRepo;

        [BindProperty]
        public InquiryVM InquiryVM { get; set; }

        public InquiryController(IInquiryHeaderRepository inqHeaderRepo,
            IInquiryDetailRepository inqDetailRepo)
        {
            _inqHeaderRepo = inqHeaderRepo;
            _inqDetailRepo = inqDetailRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            InquiryVM = new InquiryVM()
            {
                InquiryHeader = _inqHeaderRepo.FirstOrDefault(u => u.Id == id),
                InquiryDetail = _inqDetailRepo.GetAll(u=> u.InquiryHeaderId == id, includePropreties:"Product")
            };
            return View(InquiryVM);
        }

        [ActionName("Details")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost()
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            InquiryVM.InquiryDetail = _inqDetailRepo.GetAll(u=>u.InquiryHeaderId == InquiryVM.InquiryHeader.Id);

            foreach (var detail in InquiryVM.InquiryDetail)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    ProductId = detail.ProductId
                };
                shoppingCartList.Add(shoppingCart);
            }
            HttpContext.Session.Clear();
            HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
            HttpContext.Session.Set(WC.SessionInquiryId, InquiryVM.InquiryHeader.Id);

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public IActionResult Delete()
        {
            InquiryHeader inquiryHeader = _inqHeaderRepo.FirstOrDefault(u => u.Id == InquiryVM.InquiryHeader.Id);
            IEnumerable<InquiryDetail> inquiryDetails = _inqDetailRepo.GetAll(u=>u.InquiryHeaderId == InquiryVM.InquiryHeader.Id);
                
            _inqDetailRepo.RemoveRange(inquiryDetails);
            _inqHeaderRepo.Remove(inquiryHeader);
            _inqHeaderRepo.Save();

            TempData[WC.Success] = "Item removed from inquiry successfully";
            return RedirectToAction(nameof(Index));
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetInquiryList()
        {
            return Json(new { data = _inqHeaderRepo.GetAll() });
        }

        #endregion
    }
}
