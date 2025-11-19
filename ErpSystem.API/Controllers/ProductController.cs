using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpSystem.API.Data;
using ErpSystem.API.Models;

namespace ErpSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ErpDbContext _context;

        public ProductController(ErpDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        /// <summary>
        /// Tüm ürünlerin listesini döndürür.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Veritabanından tüm ürünleri çek
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        /// <summary>
        /// Belirtilen ID'ye sahip ürünü döndürür.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // 404
            }

            return product;
        }
        
        // POST: api/Product
        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Yeni oluşturulan kaynağın URL'ini döndürür (HTTP 201 Created)
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}