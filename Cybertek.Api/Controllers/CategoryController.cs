using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryHelper _categoryHelper;

        public CategoryController(ICategoryHelper categoryHelper)
        {
            _categoryHelper = categoryHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await _categoryHelper.GetCategories();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{catId}")]
        public async Task<IActionResult> Get(Guid catId)
        {
            try
            {
                var category = await _categoryHelper.GetCategory(catId);
                return Ok(category);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public void Post([FromBody] CategoryEntity entity)
        {
            _categoryHelper.AddCategory(entity);
        }

        [HttpPut("{catId}")]
        public void Update(Guid catId, [FromBody] CategoryEntity entity)
        {
            _categoryHelper.UpdateCategory(entity);
        }


        [HttpDelete("{catId}")]
        public void Delete(CategoryEntity entity)
        {
            _categoryHelper.DeleteCategory(entity);
        }
    }
}
