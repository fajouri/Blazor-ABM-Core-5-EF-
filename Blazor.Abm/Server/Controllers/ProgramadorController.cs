using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blazor.Abm.Server.Data;
using Blazor.Abm.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Abm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramadorController : ControllerBase
    {
        private readonly AplicacionDbContext _context;

        public ProgramadorController(AplicacionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var programadores = await _context.Programadores.ToListAsync();
            return Ok(programadores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var programador = await _context.Programadores.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(programador);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Programador programador)
        {
            _context.Add(programador);
            await _context.SaveChangesAsync();
            return Ok(programador.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Programador programador)
        {
            _context.Entry(programador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var programador = new Programador { Id = id };
            _context.Remove(programador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
