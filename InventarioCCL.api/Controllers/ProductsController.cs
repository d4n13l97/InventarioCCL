using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using InventarioCCL.api.Data;
using InventarioCCL.api.Models;

namespace InventarioCCL.api.Controllers
{
    [ApiController]
    [Route("productos")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("inventario")]
        public async Task<IActionResult> GetInventory()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpPost("movimiento")]
        public async Task<IActionResult> RegisterMovement([FromBody] ProductMovementRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);

            if (product == null)
                return NotFound("producto no encontrado");

            if (request.Type == "entrada")
            {
                product.quantity += request.Quantity;
            }
            else if (request.Type == "salida")
            {
                if (product.quantity < request.Quantity)
                    return BadRequest("stock insuficiente");

                product.quantity -= request.Quantity;
            }
            else
            {
                return BadRequest("tipo invalido");
            }

            await _context.SaveChangesAsync();

            return Ok(product);
        }
    }
}