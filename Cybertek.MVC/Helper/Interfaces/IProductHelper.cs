using Cybertek.Entities.Entities;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper.Interfaces
{
    public interface IProductHelper
    {
        public Task<IEnumerable<ProductEntity>> GetProducts(bool active);
        public ProductViewModel GetProductViewModel(string searchText, bool active);
        public Task SaveProduct(AddEditProductViewModel model);
        public Task<AddEditProductViewModel> GetAddEditProductViewModel(Guid prodId);
        public Task DeleteProduct(Guid prodId);
    }
}
