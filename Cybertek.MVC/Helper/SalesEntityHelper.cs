using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper
{
    public class SalesEntityHelper : ISalesEntityHelper
    {
        private readonly IUnitOfWork _uow;

        public SalesEntityHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeleteSale(Guid salesId)
        {
            var entity = await _uow.Sales.GetAsync(salesId);
            _uow.Sales.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditSalesViewModel> GetAddEditSalesViewModel(Guid salesId)
        {
            var model = new AddEditSalesViewModel();
            model.Sale = await _uow.Sales.GetAsync(w => w.SalesId == salesId);
            return model;
        }

        public async Task<IEnumerable<SalesEntity>> GetSales(bool active)
        {
            return await _uow.Sales.GetAllAsync(w => w.Active == active);
        }

        public SalesViewModel GetSalesViewModel(string searchText, bool active)
        {
            var model = new SalesViewModel();
            model.SearchText = searchText ?? "";
            model.Sales = _uow.Sales.GetAllAsync(w => w.Active == active && w.CustomerName
            .Contains(model.SearchText)).Result.ToList();
            return model;
        }

        public async Task SaveSale(AddEditSalesViewModel model)
        {
            if (model.Sale.SalesId == Guid.Empty)
            {
                await _uow.Sales.AddAsync(model.Sale);
            }
            else
            {
                _uow.Sales.Update(model.Sale);
            }
            _uow.CompleteUOW();
        }
    }
}
