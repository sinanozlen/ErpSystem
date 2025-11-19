using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpSystem.API.Data;
using ErpSystem.API.Models;

namespace ErpSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariAccountController : ControllerBase
    {
        private readonly ErpDbContext _context;

        public CariAccountController(ErpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CariAccount>>> GetAccounts()
        {
            return await _context.CariAccounts.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CariAccount>> PostAccount(CariAccount account)
        {
            _context.CariAccounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccounts), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, CariAccount account)
        {
            if (id != account.Id)
                return BadRequest();

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var acc = await _context.CariAccounts.FindAsync(id);
            if (acc == null)
                return NotFound();

            _context.CariAccounts.Remove(acc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
