using Cybertek.Entities.Entities;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper.Interfaces
{
    public interface ICategoryHelper
    {
        public Task<IEnumerable<CategoryEntity>> GetCategories(bool active);
        public CategoryViewModel GetCategoryViewModel(string searchText, bool active);
        public Task SaveCategory(AddEditCategoryViewModel model);
        public Task<AddEditCategoryViewModel> GetAddEditCategoryViewModel(Guid catId);
        public Task DeleteCategory(Guid catId);
    }
}
