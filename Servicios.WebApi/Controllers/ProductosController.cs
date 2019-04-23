using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.BusinessLogic.Intefaces;
using Servicios.Models;
using Servicios.WebApi.Models;

namespace Servicios.WebApi.Controllers
{
    [Route("api/Productos")]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosLogic _logic;

        public ProductosController(IProductosLogic logic)
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
        [Route("ListaProductos")]
        public IActionResult GetPaginatedSupplier([FromBody] GetPaginatedSupplier request)
        {
            return Ok(_logic.ProductosListaPaginada(request.Page, request.Rows, request.SearchTerm));
        }

        [HttpPost]
        [Route("Agregar")]
        public IActionResult Post([FromBody] Inv_Productos producto)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_logic.Insert(producto));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Inv_Productos producto)
        {
            if (ModelState.IsValid && _logic.Update(producto))
            {
                return Ok(new { Message = "The product is Updated" });
            }

            return BadRequest();

        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Inv_Productos producto)
        {

            if (producto.Id > 0)
            {
                return Ok(_logic.Delete(producto));

            }

            return BadRequest();

        }

    }
}