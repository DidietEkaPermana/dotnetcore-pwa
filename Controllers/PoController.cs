using System;
using System.Threading.Tasks;
using AppCore.BLL;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppCore.Controllers
{
    [Route("api/[controller]")]
    public class PoController : Controller
    {
        PoManager poManager;
        public PoController(IUnitOfWork _unitOfWork)
        {
            poManager = new PoManager(_unitOfWork);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetHeader()
        {
            try
            {
                var result =  await poManager.GetHeader();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]/{OrderId}")]
        public async Task<IActionResult> GetItem(long OrderId)
        {
            try
            {
                var result =  await poManager.GetItem(OrderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("[action]/{OrderItemId}")]
        public async Task<IActionResult> GetItemDetail(long OrderItemId)
        {
            try
            {
                var result =  await poManager.GetItemDetail(OrderItemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}