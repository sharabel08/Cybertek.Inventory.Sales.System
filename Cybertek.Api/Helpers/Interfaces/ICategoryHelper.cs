using Cybertek.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cybertek.Api.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        public Task<CategoryEntity> GetCategory(Guid catId);
        public Task<IEnumerable<CategoryEntity>> GetCategories();
        public Task AddCategory(CategoryEntity entity);
        public Task UpdateCategory(CategoryEntity entity);
        public Task DeleteCategory(CategoryEntity entity);
    }
}
