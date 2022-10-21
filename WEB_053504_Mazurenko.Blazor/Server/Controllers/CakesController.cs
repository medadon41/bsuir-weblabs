using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CakesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cake>>> GetCakes(int? group)
        {
            if (group == null)
            {
                return await _context.Cakes.ToListAsync();
            }
            return await _context.Cakes.Include(g => g.Group).Where(cg => cg.Group.Id == group).ToListAsync();
        }

        // GET: api/Cakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(int id)
        {
            var cake = await _context.Cakes.FindAsync(id);

            if (cake == null)
            {
                return NotFound();
            }

            return cake;
        }

        // PUT: api/Cakes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCake(int id, Cake cake)
        {
            if (id != cake.Id)
            {
                return BadRequest();
            }

            _context.Entry(cake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CakeExists(id))
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

        // POST: api/Cakes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCake(Cake cake)
        {
            _context.Cakes.Add(cake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCake", new { id = cake.Id }, cake);
        }

        // DELETE: api/Cakes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCake(int id)
        {
            var cake = await _context.Cakes.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }

            _context.Cakes.Remove(cake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CakeExists(int id)
        {
            return _context.Cakes.Any(e => e.Id == id);
        }
    }
}
