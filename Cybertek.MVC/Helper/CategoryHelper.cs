using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork;
using Cybertek.Entities.UnitOfWork.Interfaces;
using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper
{
    public class CategoryHelper : ICategoryHelper
    {
        private readonly IUnitOfWork _uow;

        public CategoryHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeleteCategory(Guid catId)
        {
            var entity = await _uow.Categories.GetAsync(catId);
            _uow.Categories.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditCategoryViewModel> GetAddEditCategoryViewModel(Guid catId)
        {
            var model = new AddEditCategoryViewModel();
            await _uow.Categories.GetAllAsync(w => w.CategoryId == catId);
            return model;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories(bool active)
        {
            return await _uow.Categories.GetAllAsync(w => w.Active == active);
        }

        public CategoryViewModel GetCategoryViewModel(string searchText, bool active)
        {
            var model = new CategoryViewModel();
            model.SearchText = searchText ?? "";
            model.Categories = _uow.Categories.GetAllAsync(w => w.Active == active && w.CategoryName
            .Contains(model.SearchText)).Result.ToList();
            return model;
            
        }

        public async Task SaveCategory(AddEditCategoryViewModel model)
        {
            if(model.Category.CategoryId == Guid.Empty)
            {
                await _uow.Categories.AddAsync(model.Category);
            }
            else
            {
                _uow.Categories.Update(model.Category);
            }
            _uow.CompleteUOW();
        }
    }
}
