using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers
{
    public class ProductHelper : IProductHelper
    {
        private readonly IUnitOfWork _uow;

        public ProductHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task AddProduct(ProductEntity entity)
        {
            await _uow.Products.AddAsync(entity);
            _uow.CompleteUOW();
        }

        public async Task DeleteProduct(ProductEntity entity)
        {
            _uow.Products.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<ProductEntity> GetProduct(Guid prodId)
        {
            return await _uow.Products.GetAsync(prodId);
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _uow.Products.GetAllAsync();
        }

        public async Task UpdateProduct(ProductEntity entity)
        {
            _uow.Products.Update(entity);
            _uow.CompleteUOW();
        }
    }
}
