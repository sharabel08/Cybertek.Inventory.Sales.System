using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork;
using Cybertek.MVC.Helper.Interfaces;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper
{
    public class PurchasingHelper : IPurchasingHelper
    {
        private readonly UnitOfWork _uow;

        public PurchasingHelper(UnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task DeletePurchasing(Guid purchId)
        {
            var entity = await _uow.Purchases.GetAsync(purchId);
            _uow.Purchases.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<AddEditPurchasingViewModel> GetAddEditPurchasingViewModel(Guid purchId)
        {
            var model = new AddEditPurchasingViewModel();
            model.Purchasing = await _uow.Purchases.GetAsync(w => w.PurchasingId == purchId);
            return model;
        }

        public async Task<IEnumerable<PurchasingEntity>> GetPurchasings(bool active)
        {
            return await _uow.Purchases.GetAllAsync();
        }

        public PurchasingViewModel GetPurchasingViewModel(string searchText, bool active)
        {
            var model = new PurchasingViewModel();
            model.SearchText = searchText ?? "";
            model.Purchasings = _uow.Purchases.GetAllAsync().Result.ToList();
            return model;
        }

        public async Task SavePurchasing(AddEditPurchasingViewModel model)
        {
            if (model.Purchasing.PurchasingId == Guid.Empty)
            {
                await _uow.Purchases.AddAsync(model.Purchasing);
            }
            else
            {
                _uow.Purchases.Update(model.Purchasing);
            }
            _uow.CompleteUOW();
        }
    }
}
