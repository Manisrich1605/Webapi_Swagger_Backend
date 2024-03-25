using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPrpject1.Models;
using Microsoft.AspNetCore.Hosting;

namespace ApiPrpject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsregisterController : ControllerBase
    {
        private readonly LeaveTypeContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public JsregisterController(LeaveTypeContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Jsregister
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jsregister>>> GetJsregister()
        {
            return await _context.Jsregisters.ToListAsync();
        }

        // GET: api/Jsregister/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jsregister>> GetJsregister(int id)
        {
            var jsregister = await _context.Jsregisters.FindAsync(id);

            if (jsregister == null)
            {
                return NotFound();
            }

            return jsregister;
        }

        // PUT: api/Jsregister/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJsregister(int id, Jsregister jsregister)
        {
            if (id != jsregister.Id)
            {
                return BadRequest();
            }

            _context.Entry(jsregister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JsregisterExists(id))
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

        // POST: api/Jsregister
        [HttpPost]
        public async Task<ActionResult<Jsregister>> PostJsregister(Jsregister jsregister)
        {
            using (var ms = new MemoryStream())
            {
                await jsregister.Image.CopyToAsync(ms);
                jsregister.ImageData = Convert.ToBase64String(ms.ToArray());
            }

            _context.Jsregisters.Add(jsregister);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJsregister), new { id = jsregister.Id }, jsregister);
        }
        // DELETE: api/Jsregister/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jsregister>> DeleteJsregister(int id)
        {
            var jsregister = await _context.Jsregisters.FindAsync(id);
            if (jsregister == null)
            {
                return NotFound();
            }

            _context.Jsregisters.Remove(jsregister);
            await _context.SaveChangesAsync();

            return jsregister;
        }

        private bool JsregisterExists(int id)
        {
            return _context.Jsregisters.Any(e => e.Id == id);
        }
    }
}