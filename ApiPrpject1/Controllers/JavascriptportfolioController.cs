using ApiPrpject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPrpject1.Controllers
{
    [Route("api/[controller]")]//route for the controller
    [ApiController]//secify controller is the API controller and handle everything
    public class JavascriptportfolioController : ControllerBase
    {
        private readonly LeaveTypeContext _leavetypeContext;//initailize controller with instance LeaveTypeContext
        public JavascriptportfolioController(LeaveTypeContext leavetypeContext)
        {
            _leavetypeContext = leavetypeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Javascriptportfolio>>> GetJavascriptportfolios()//get data from dbase
        {
            if (_leavetypeContext.Javascriptportfolios == null)
            {
                return NotFound();
            }
            return await _leavetypeContext.Javascriptportfolios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Javascriptportfolio>> GetJavascriptportfolio(int id)//get data by id
        {
            if (_leavetypeContext.Javascriptportfolios == null)
            {
                return NotFound();
            }

            var javascriptportfolio = await _leavetypeContext.Javascriptportfolios.FindAsync(id);
            if (javascriptportfolio == null)
            {
                return NotFound();
            }
            return javascriptportfolio;
        }

        [HttpPost]
        public async Task<ActionResult<Javascriptportfolio>> PostJavascriptportfolios(Javascriptportfolio javascriptportfolio)//create new
        {
            _leavetypeContext.Javascriptportfolios.Add(javascriptportfolio);
            await _leavetypeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJavascriptportfolio), new { id = javascriptportfolio.Id }, javascriptportfolio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutJavascriptportfolios(int id, Javascriptportfolio javascriptportfolio)//update existing one by id
        {
            if (id != javascriptportfolio.Id)
            {
                return BadRequest();
            }
            _leavetypeContext.Entry(javascriptportfolio).State = EntityState.Modified;
            try
            {
                await _leavetypeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJavascriptportfolios(int id)//delete particuar record
        {
            if (_leavetypeContext.Javascriptportfolios == null)
            {
                return NotFound();
            }
            var javascriptportfolio = await _leavetypeContext.Javascriptportfolios.FindAsync(id);
            if (javascriptportfolio == null)
            {
                return NotFound();

            }
            _leavetypeContext.Javascriptportfolios.Remove(javascriptportfolio);
            await _leavetypeContext.SaveChangesAsync();
            return Ok();
        }
    }
}










