using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpSystem.API.Data;
using ErpSystem.API.Models;

namespace ErpSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariAccountController : ControllerBase
    {
        private readonly ErpDbContext _context;

        public CariAccountController(ErpDbContext context)
        {
            _context = context;
        }

        // GET: api/CariAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CariAccount>>> GetAll()
        {
            var list = await _context.CariAccounts.AsNoTracking().ToListAsync();
            return Ok(list);
        }

        // GET: api/CariAccount/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CariAccount>> Get(int id)
        {
            var item = await _context.CariAccounts.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/CariAccount
        [HttpPost]
        public async Task<ActionResult<CariAccount>> Create([FromBody] CariAccount model)
        {
            if (model == null) return BadRequest();

            // Basit validation
            if (string.IsNullOrWhiteSpace(model.Name))
                return BadRequest(new { title = "Name is required." });

            // Ensure initial balance is set (optional business rule)
            model.Balance = model.Balance;

            _context.CariAccounts.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        // PUT: api/CariAccount/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CariAccount model)
        {
            if (model == null || id != model.Id) return BadRequest();

            var existing = await _context.CariAccounts.FindAsync(id);
            if (existing == null) return NotFound();

            // Güncellenecek alanlar
            existing.Name = model.Name;
            existing.AccountType = model.AccountType;
            existing.TaxId = model.TaxId;
            existing.City = model.City;
            existing.Balance = model.Balance;

            _context.CariAccounts.Update(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/CariAccount/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _context.CariAccounts.FindAsync(id);
            if (existing == null) return NotFound();

            _context.CariAccounts.Remove(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
