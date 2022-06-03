using Cybertek.Entities.Entities;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper.Interfaces
{
    public interface ISupplierHelper
    {
        public Task<IEnumerable<SupplierEntity>> GetSuppliers(bool active);
        public SupplierViewModel GetSupplierViewModel(string searchText, bool active);
        public Task SaveSupplier(AddEditSupplierViewModel model);
        public Task<AddEditSupplierViewModel> GetAddEditSupplierViewModel(Guid supId);
        public Task DeleteSupplier(Guid supId);
    }
}
