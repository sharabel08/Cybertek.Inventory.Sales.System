using Cybertek.Entities.Entities;
using Cybertek.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.MVC.Helper.Interfaces
{
    public interface IPurchasingHelper
    {
        public Task<IEnumerable<PurchasingEntity>> GetPurchasings(bool active);
        public PurchasingViewModel GetPurchasingViewModel(string searchText, bool active);
        public Task SavePurchasing(AddEditPurchasingViewModel model);
        public Task<AddEditPurchasingViewModel> GetAddEditPurchasingViewModel(Guid purchId);
        public Task DeletePurchasing(Guid purchId);
    }
}
