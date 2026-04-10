using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventarioCCL.api.Models;
using System.Linq;

namespace InventarioCCL.api.Controllers
{
    [ApiController]
    [Route("productos")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        // inventario en memoria
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Producto A", Quantity = 10 },
            new Product { Id = 2, Name = "Producto B", Quantity = 20 }
        };

        [HttpGet("inventario")]
        public IActionResult GetInventory()
        {
            return Ok(products);
        }

        [HttpPost("movimiento")]
        public IActionResult RegisterMovement([FromBody] ProductMovementRequest request)
        {
            var product = products.FirstOrDefault(p => p.Id == request.ProductId);

            if (product == null)
                return NotFound("producto no encontrado");

            if (request.Type == "entrada")
            {
                product.Quantity += request.Quantity;
            }
            else if (request.Type == "salida")
            {
                if (product.Quantity < request.Quantity)
                    return BadRequest("stock insuficiente");

                product.Quantity -= request.Quantity;
            }
            else
            {
                return BadRequest("tipo invalido");
            }

            return Ok(product);
        }
    }
}