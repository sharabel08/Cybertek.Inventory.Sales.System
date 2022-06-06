using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers
{
    public class PurchasingHelper : IPurchasingHelper
    {
        private readonly IUnitOfWork _uow;

        public PurchasingHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task AddPurchase(PurchasingEntity entity)
        {
            await _uow.Purchases.AddAsync(entity);
            _uow.CompleteUOW();
        }

        public async Task DeletePurchase(PurchasingEntity entity)
        {
            _uow.Purchases.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<PurchasingEntity> GetPurchase(Guid purchId)
        {
            return await _uow.Purchases.GetAsync(purchId);
        }

        public async Task<IEnumerable<PurchasingEntity>> GetPurchases()
        {
            return await _uow.Purchases.GetAllAsync();
        }

        public async Task UpdatePurchase(PurchasingEntity entity)
        {
            _uow.Purchases.Update(entity);
            _uow.CompleteUOW();
        }
    }
}
