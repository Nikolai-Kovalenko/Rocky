using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rocky_DatAccess.Repository.IRepository;
using Rocky_Models.ViewModels;
using Rocky_Utility;
using Rocky_Utility.BrainTree;
using System.Linq;

namespace Rocky.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDetailRepository _ordDetailRepo;
        private readonly IOrderHeaderRepository _ordHeaderRepo;
        public readonly IBrainTreeGate _brain;


        public OrderController(IOrderDetailRepository ordDetailRepo, IOrderHeaderRepository ordHeaderRepo,
            IBrainTreeGate brain)
        {
            _ordHeaderRepo = ordHeaderRepo;
            _ordDetailRepo = ordDetailRepo;
            _brain = brain;
        }

        public IActionResult Index()
        {
            OrderListVM orderListVM = new OrderListVM()
            {
                OrderHeaderList = _ordHeaderRepo.GetAll(),
                StatusList = WC.ListStatus.ToList().Select(i => new SelectListItem
                {
                    Text=i,
                    Value=i
                })
            };

            return View(orderListVM);
        }
    }
}
