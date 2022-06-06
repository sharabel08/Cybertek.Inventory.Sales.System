using Cybertek.Api.Helpers.Interfaces;
using Cybertek.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cybertek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private readonly IPurchasingHelper _purchasingHelper;

        public PurchasingController(IPurchasingHelper purchasingHelper)
        {
            _purchasingHelper = purchasingHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var purchases = await _purchasingHelper.GetPurchases();
                return Ok(purchases);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{purchId}")]
        public async Task<IActionResult> Get(Guid purchId)
        {
            try
            {
                var purchase = await _purchasingHelper.GetPurchase(purchId);
                return Ok(purchase);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public void Post([FromBody] PurchasingEntity entity)
        {
            _purchasingHelper.AddPurchase(entity);
        }

        [HttpPut("{purchId}")]
        public void Update(Guid purchId, [FromBody] PurchasingEntity entity)
        {
            _purchasingHelper.UpdatePurchase(entity);
        }


        [HttpDelete("{purchId}")]
        public void Delete(PurchasingEntity entity)
        {
            _purchasingHelper.DeletePurchase(entity);
        }

    }

}
