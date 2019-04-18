using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servicios.Models;
using Servicios.BusinessLogic.Intefaces;

namespace Servicios.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderLogic _logic;

        public OrderController(IOrderLogic logic)
        {
            _logic = logic;

        }

        [HttpGet]
        [Route("GetPaginatedOrders/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrders(int page, int rows)
        {
            return Ok(_logic.getPaginatedOrder(page, rows));
        }
        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId) {
            return Ok(_logic.GetOrderById(orderId));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            return Ok(_logic.Delete(new Order() { Id =id}));
        }


    }
}
