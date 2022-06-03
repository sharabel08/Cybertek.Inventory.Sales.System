using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.MVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierHelper _supplierHelper;

        public SupplierController(ISupplierHelper supplierHelper)
        {
            _supplierHelper = supplierHelper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Supplier(string search, bool active = true)
        {
            var model = _supplierHelper.GetSupplierViewModel(search, active);
            return View(model);

        }
        public async Task<IActionResult> AddEditSupplier(Guid supId)
        {
            AddEditSupplierViewModel model = new AddEditSupplierViewModel();
            if (supId != Guid.Empty)
            {
                model = await _supplierHelper.GetAddEditSupplierViewModel(supId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveSupplier(AddEditSupplierViewModel model)
        {
            _supplierHelper.SaveSupplier(model);
            return RedirectToAction("Supplier");
        }

        public async Task<IActionResult> DeleteSupplier(Guid supId)
        {
            await _supplierHelper.DeleteSupplier(supId);
            return RedirectToAction("Supplier");
        }

        public IActionResult Search(SupplierViewModel model)
        {
            return RedirectToAction("Supplier", new { search = model.SearchText });
        }
    }
}
