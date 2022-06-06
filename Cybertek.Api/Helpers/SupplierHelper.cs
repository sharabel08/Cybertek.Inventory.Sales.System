using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers
{
    public class SupplierHelper : ISupplierHelper
    {
        private readonly IUnitOfWork _uow;

        public SupplierHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task AddSupplier(SupplierEntity entity)
        {
            await _uow.Suppliers.AddAsync(entity);
            _uow.CompleteUOW();
        }

        public async Task DeleteSupplier(SupplierEntity entity)
        {
            _uow.Suppliers.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<SupplierEntity> GetSupplier(Guid supId)
        {
            return await _uow.Suppliers.GetAsync(supId);
        }

        public async Task<IEnumerable<SupplierEntity>> GetSuppliers()
        {
            return await _uow.Suppliers.GetAllAsync();
        }

        public async Task UpdateSupplier(SupplierEntity entity)
        {
            _uow.Suppliers.Update(entity);
            _uow.CompleteUOW();
        }
    }
}
