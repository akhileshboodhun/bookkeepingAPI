using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bookkeepingAPI.Models;

namespace bookkeepingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashbooksController : ControllerBase
    {
        private readonly bkcontext _context;

        public CashbooksController(bkcontext context)
        {
            _context = context;
        }

        // GET: api/Cashbooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cashbook>>> GetCashbook()
        {
            return await _context.Cashbook.ToListAsync();
        }

        // GET: api/Cashbooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cashbook>> GetCashbook(int id)
        {
            var cashbook = await _context.Cashbook.FindAsync(id);

            if (cashbook == null)
            {
                return NotFound();
            }

            return cashbook;
        }

        // PUT: api/Cashbooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCashbook(int id, Cashbook cashbook)
        {
            if (id != cashbook.receipt_no)
            {
                return BadRequest();
            }

            _context.Entry(cashbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CashbookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cashbooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cashbook>> PostCashbook(Cashbook cashbook)
        {
            _context.Cashbook.Add(cashbook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCashbook", new { id = cashbook.receipt_no }, cashbook);
        }

        // DELETE: api/Cashbooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cashbook>> DeleteCashbook(int id)
        {
            var cashbook = await _context.Cashbook.FindAsync(id);
            if (cashbook == null)
            {
                return NotFound();
            }

            _context.Cashbook.Remove(cashbook);
            await _context.SaveChangesAsync();

            return cashbook;
        }

        private bool CashbookExists(int id)
        {
            return _context.Cashbook.Any(e => e.receipt_no == id);
        }
    }
}
