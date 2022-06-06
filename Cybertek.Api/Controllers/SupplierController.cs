using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cybertek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierHelper _supplierHelper;

        public SupplierController(ISupplierHelper supplierHelper)
        {
            _supplierHelper = supplierHelper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var suppliers = await _supplierHelper.GetSuppliers();
                return Ok(suppliers);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{supId}")]
        public async Task<IActionResult> Get(Guid supId)
        {
            try
            {
                var supplier = await _supplierHelper.GetSupplier(supId);
                return Ok(supplier);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public void Post([FromBody] SupplierEntity entity)
        {
            _supplierHelper.AddSupplier(entity);
        }

        [HttpPut("{supId}")]
        public void Update(Guid supId, [FromBody] SupplierEntity entity)
        {
            _supplierHelper.UpdateSupplier(entity);
        }


        [HttpDelete("{supId}")]
        public void Delete(SupplierEntity entity)
        {
            _supplierHelper.DeleteSupplier(entity);
        }

    }
}
