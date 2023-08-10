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

        #region API CALLS
        [HttpGet]
        public IActionResult GetInquiryList()
        {
            return Json(new { data = _inqHeaderRepo.GetAll() });
        }

        #endregion
    }
}
