using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.WebApi.Models;

namespace Servicios.WebApi.Controllers
{
    [Route("api/Supplier")]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierLogic _logic;

        public SupplierController(ISupplierLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_logic.GetById(id));
        }

        [HttpPost]
        [Route("GetPaginatedSupplier")]
        public IActionResult GetPaginatedSupplier([FromBody] GetPaginatedSupplier request)
        {
            return Ok(_logic.SupplierPageList(request.Page, request.Rows, request.SearchTerm));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(supplier));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Supplier supplier)
        {
            if (ModelState.IsValid && _logic.Update(supplier))
            {
                return Ok(new { Message = "The Supplier is Updated" });
            }

            return BadRequest();

        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Supplier supplier)
        {

            if (supplier.Id > 0)
            {
                return Ok(_logic.Delete(supplier));

            }

            return BadRequest();

        }

    }
}