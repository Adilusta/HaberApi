using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaberApiController : ControllerBase
    {
        private HaberDbContext context;

        public HaberApiController(HaberDbContext ctx)
        {
            context = ctx;
        }

        [HttpGet("gethaberler")]
        public IAsyncEnumerable<Haber> GetHaberler()
        {
            return context.Haberler;
        }

        [HttpGet("gethaber/{id}")]
        public async Task<IActionResult> GetHaber(long id)
        {
            Haber p = await context.Haberler.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                HaberId = p.HaberId,
                HaberBasligi = p.HaberBasligi,
                HaberIcerigi = p.HaberIcerigi,
                HaberTarihi = p.HaberTarihi
            });
        }

        [HttpPost("savehaber")]
        public async Task<IActionResult> SaveProduct(HaberBindingTarget target)
        {
            Haber p = target.ToHaber();
            await context.Haberler.AddAsync(p);
            await context.SaveChangesAsync();
            return Ok(p);
        }

        [HttpPut("updatehaber")]
        public async Task UpdateHaber(Haber haber)
        {
            context.Update(haber);
            await context.SaveChangesAsync();
        }

        [HttpDelete("deletehaber/{id}")]
        public async Task DeleteHaber(long id)
        {
            context.Haberler.Remove(new Haber() { HaberId = id });
            await context.SaveChangesAsync();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetHaber), new { Id = 1 });
        }

    }
}
