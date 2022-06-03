using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.MVC.Controllers
{
    public class PurchasingController : Controller
    {
        private readonly IPurchasingHelper _purchasingHelper;

        public PurchasingController(IPurchasingHelper purchasingHelper)
        {
            _purchasingHelper = purchasingHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Purchasing(string search, bool active = true)
        {
            var model = _purchasingHelper.GetPurchasingViewModel(search, active);
            return View(model);

        }
        public async Task<IActionResult> AddEditPurchasing(Guid purchId)
        {
            AddEditPurchasingViewModel model = new AddEditPurchasingViewModel();
            if (purchId != Guid.Empty)
            {
                model = await _purchasingHelper.GetAddEditPurchasingViewModel(purchId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SavePurchasing(AddEditPurchasingViewModel model)
        {
            _purchasingHelper.SavePurchasing(model);
            return RedirectToAction("Purchasing");
        }

        public async Task<IActionResult> DeletePurchasing(Guid purchId)
        {
            await _purchasingHelper.DeletePurchasing(purchId);
            return RedirectToAction("Purchasing");
        }

        public IActionResult Search(PurchasingViewModel model)
        {
            return RedirectToAction("Purchasing", new { search = model.SearchText });
        }


    }
}
