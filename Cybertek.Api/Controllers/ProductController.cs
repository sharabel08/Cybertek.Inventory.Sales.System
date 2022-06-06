using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductHelper _productHelper;

        public ProductController(IProductHelper productHelper)
        {
            _productHelper = productHelper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await _productHelper.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{prodId}")]
        public async Task<IActionResult> Get(Guid prodId)
        {
            try
            {
                var product = await _productHelper.GetProduct(prodId);
                return Ok(product);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public void Post([FromBody] ProductEntity entity)
        {
            _productHelper.AddProduct(entity);
        }

        [HttpPut("{prodId}")]
        public void Update(Guid prodId, [FromBody] ProductEntity entity)
        {
            _productHelper.UpdateProduct(entity);
        }


        [HttpDelete("{prodId}")]
        public void Delete(ProductEntity entity)
        {
            _productHelper.DeleteProduct(entity);
        }


    }
}
