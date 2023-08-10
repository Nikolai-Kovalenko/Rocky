using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky_DatAccess;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models;
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

        #region API CALLS
        [HttpGet]
        public IActionResult GetInquiryList()
        {
            return Json(new { data = _inqHeaderRepo.GetAll() });
        }

        #endregion
    }
}
