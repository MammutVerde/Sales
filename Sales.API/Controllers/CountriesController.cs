using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/v1/countries")]

    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync (Country country)
        {
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var afectedRows = await _context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.Include(x=>x.States).ToArrayAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsyn (Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            return Ok(await _context.Countries
                .Include(x => x.States!)
                .ThenInclude(x => x.Cities)
                .ToListAsync());
        }

    }
}
