using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.MVC.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISalesEntityHelper _salesEntityHelper;

        public SaleController(ISalesEntityHelper salesEntityHelper)
        {
            _salesEntityHelper = salesEntityHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sale(string search, bool active = true)
        {
            var model = _salesEntityHelper.GetSalesViewModel(search, active);
            return View(model);

        }
        public async Task<IActionResult> AddEditSale(Guid salesId)
        {
            AddEditSalesViewModel model = new AddEditSalesViewModel();
            if (salesId != Guid.Empty)
            {
                model = await _salesEntityHelper.GetAddEditSalesViewModel(salesId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveSale(AddEditSalesViewModel model)
        {
            _salesEntityHelper.SaveSale(model);
            return RedirectToAction("Sale");
        }

        public async Task<IActionResult> DeleteSale(Guid salesId)
        {
            await _salesEntityHelper.DeleteSale(salesId);
            return RedirectToAction("Sale");
        }

        public IActionResult Search(SalesViewModel model)
        {
            return RedirectToAction("Sale", new { search = model.SearchText });
        }

    }
}
