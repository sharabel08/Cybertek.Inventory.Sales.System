using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductHelper _productHelper;

        public ProductController(IProductHelper productHelper)
        {
            _productHelper = productHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product(string search, bool active = true)
        {
            var model = _productHelper.GetProductViewModel(search, active);
            return View(model);

        }
        public async Task<IActionResult> AddEditProduct(Guid prodId)
        {
            AddEditProductViewModel model = new AddEditProductViewModel();
            model = await _productHelper.GetAddEditProductViewModel(prodId);
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveProduct(AddEditProductViewModel model)
        {
            _productHelper.SaveProduct(model);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> DeleteProduct(Guid prodId)
        {
            await _productHelper.DeleteProduct(prodId);
            return RedirectToAction("Product");
        }

        public IActionResult Search(ProductViewModel model)
        {
            return RedirectToAction("Product", new { search = model.SearchText });
        }
    }
}
