using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Cybertek.Entities.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers
{
    public class CategoryHelper : ICategoryHelper
    {
        private readonly IUnitOfWork _uow;

        public CategoryHelper(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task AddCategory(CategoryEntity entity)
        {
            await _uow.Categories.AddAsync(entity);
            _uow.CompleteUOW();
        }

        public async Task DeleteCategory(CategoryEntity entity)
        {
            _uow.Categories.Remove(entity);
            _uow.CompleteUOW();
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await _uow.Categories.GetAllAsync();
        }

        public async Task<CategoryEntity> GetCategory(Guid catId)
        {
            return await _uow.Categories.GetAsync(catId);
        }

        public async Task UpdateCategory(CategoryEntity entity)
        {
            _uow.Categories.Update(entity);
            _uow.CompleteUOW();
        }
    }
}
