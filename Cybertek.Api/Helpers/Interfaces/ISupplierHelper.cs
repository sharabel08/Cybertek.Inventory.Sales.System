using Cybertek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers.Interfaces
{
    public interface ISupplierHelper
    {
        public Task<SupplierEntity> GetSupplier(Guid supId);
        public Task<IEnumerable<SupplierEntity>> GetSuppliers();
        public Task AddSupplier(SupplierEntity entity);
        public Task UpdateSupplier(SupplierEntity entity);
        public Task DeleteSupplier(SupplierEntity entity);
    }
}
