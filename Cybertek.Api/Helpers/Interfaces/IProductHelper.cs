using Cybertek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers.Interfaces
{
    public interface IProductHelper
    {
        public Task<ProductEntity> GetProduct(Guid prodId);
        public Task<IEnumerable<ProductEntity>> GetProducts();
        public Task AddProduct(ProductEntity entity);
        public Task UpdateProduct(ProductEntity entity);
        public Task DeleteProduct(ProductEntity entity);
    }
}
