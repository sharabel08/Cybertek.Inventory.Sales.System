using Cybertek.Entities.Entities;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper.Interfaces
{
    public interface ISalesEntityHelper
    {
        public Task<IEnumerable<SalesEntity>> GetSales(bool active);
        public SalesViewModel GetSalesViewModel(string searchText, bool active);
        public Task SaveSale(AddEditSalesViewModel model);
        public Task<AddEditSalesViewModel> GetAddEditSalesViewModel(Guid salesId);
        public Task DeleteSale(Guid salesId);
    }
}
