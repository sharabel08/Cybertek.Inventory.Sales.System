using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryHelper _categoryHelper;

        public CategoryController(ICategoryHelper categoryHelper)
        {
            _categoryHelper = categoryHelper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(string search, bool active = true)
        {
            var model = _categoryHelper.GetCategoryViewModel(search, active);
            return View(model);

        }
        public async Task<IActionResult> AddEditCategory(Guid catId)
        {
            AddEditCategoryViewModel model = new AddEditCategoryViewModel();
            if (catId != Guid.Empty)
            {
                model = await _categoryHelper.GetAddEditCategoryViewModel(catId);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveCategory(AddEditCategoryViewModel model)
        {
            _categoryHelper.SaveCategory(model);
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> DeleteCategory(Guid catId)
        {
            await _categoryHelper.DeleteCategory(catId);
            return RedirectToAction("Category");
        }

        public IActionResult Search(CategoryViewModel model)
        {
            return RedirectToAction("Category", new { search = model.SearchText });
        }




    }
}
