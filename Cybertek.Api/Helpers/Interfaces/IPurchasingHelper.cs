using Cybertek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers.Interfaces
{
    public interface IPurchasingHelper
    {
        public Task<PurchasingEntity> GetPurchase(Guid purchId);
        public Task<IEnumerable<PurchasingEntity>> GetPurchases();
        public Task AddPurchase(PurchasingEntity entity);
        public Task UpdatePurchase(PurchasingEntity entity);
        public Task DeletePurchase(PurchasingEntity entity);
    }
}
