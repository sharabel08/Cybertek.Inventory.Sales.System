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
    public class SupplierHelper : ISupplierHelper
    {
        private readonly IUnitOfWork _uow;

        public SupplierHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeleteSupplier(Guid supId)
        {
            var entity = await _uow.Suppliers.GetAsync(supId);
            _uow.Suppliers.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditSupplierViewModel> GetAddEditSupplierViewModel(Guid supId)
        {
            var model = new AddEditSupplierViewModel();
            model.Supplier = await _uow.Suppliers.GetAsync(w => w.SupplierId == supId);
            return model;
        }

        public async Task<IEnumerable<SupplierEntity>> GetSuppliers(bool active)
        {
            return await _uow.Suppliers.GetAllAsync(w => w.Active == active);
        }

        public SupplierViewModel GetSupplierViewModel(string searchText, bool active)
        {
            var model = new SupplierViewModel();
            model.SearchText = searchText ?? "";
            model.Suppliers = _uow.Suppliers.GetAllAsync(w => w.Active == active && w.SupplierName
            .Contains(model.SearchText)).Result.ToList();
            return model;
        }

        public async Task SaveSupplier(AddEditSupplierViewModel model)
        {
            if (model.Supplier.SupplierId == Guid.Empty)
            {
                await _uow.Suppliers.AddAsync(model.Supplier);
            }
            else
            {
                _uow.Suppliers.Update(model.Supplier);
            }
            _uow.CompleteUOW();
        }
    }
}
