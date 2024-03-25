using ApiPrpject1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPrpject1.Controllers
{
    [Route("api/[controller]")]//route for the controller
    [ApiController]//secify controller is the API controller and handle everything
    public class ReactportfolioController : ControllerBase
    {
        private readonly LeaveTypeContext _leavetypeContext;//initailize controller with instance LeaveTypeContext
        public ReactportfolioController(LeaveTypeContext leavetypeContext)
        {
            _leavetypeContext = leavetypeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reactportfolio>>> GetReactportfolios()//get data from dbase
        {
            if (_leavetypeContext.Reactportfolios == null)
            {
                return NotFound();
            }
            return await _leavetypeContext.Reactportfolios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reactportfolio>> GetReactportfolio(int id)//get data by id
        {
            if (_leavetypeContext.Reactportfolios == null)
            {
                return NotFound();
            }

            var reactportfolio = await _leavetypeContext.Reactportfolios.FindAsync(id);
            if (reactportfolio == null)
            {
                return NotFound();
            }
            return reactportfolio;
        }

        [HttpPost]
        public async Task<ActionResult<Reactportfolio>> PostReactportfolios(Reactportfolio reactportfolio)//create new
        {
            _leavetypeContext.Reactportfolios.Add(reactportfolio);
            await _leavetypeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReactportfolio), new { id = reactportfolio.Id }, reactportfolio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutReactportfolios(int id, Reactportfolio reactportfolio)//update existing one by id
        {
            if (id != reactportfolio.Id)
            {
                return BadRequest();
            }
            _leavetypeContext.Entry(reactportfolio).State = EntityState.Modified;
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
        public async Task<ActionResult> DeleteReactportfolios(int id)//delete particuar record
        {
            if (_leavetypeContext.Reactportfolios == null)
            {
                return NotFound();
            }
            var reactportfolio = await _leavetypeContext.Reactportfolios.FindAsync(id);
            if (reactportfolio == null)
            {
                return NotFound();

            }
            _leavetypeContext.Reactportfolios.Remove(reactportfolio);
            await _leavetypeContext.SaveChangesAsync();
            return Ok();
        }
    }
}




    
    

    

    

    