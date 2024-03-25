using ApiPrpject1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPrpject1.Controllers
{
    [Route("api/[controller]")]//route for the controller
    [ApiController]//secify controller is the API controller and handle everything
    public class LeaveTypessController : ControllerBase
    {
        private readonly LeaveTypeContext _leavetypeContext;//initailize controller with instance LeaveTypeContext
        public LeaveTypessController(LeaveTypeContext leavetypeContext)
        {
            _leavetypeContext = leavetypeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveType>>> GetLeaveTypess()//get data from dbase
        {
            if (_leavetypeContext.LeaveTypess == null)
            {
                return NotFound();
            }
            return await _leavetypeContext.LeaveTypess.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveType>> GetLeaveType(int id)//get data by id
        {
            if (_leavetypeContext.LeaveTypess == null)
            {
                return NotFound();
            }

            var leavetype = await _leavetypeContext.LeaveTypess.FindAsync(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            return leavetype;


        }

        [HttpPost]
        public async Task<ActionResult<LeaveType>> PostLeaveTypess(LeaveType leavetype)//create new
        {
            _leavetypeContext.LeaveTypess.Add(leavetype);
            await _leavetypeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeaveType), new { id = leavetype.Id }, leavetype);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> PutLeaveTypess(int id, LeaveType leavetype)//update existing one by id
        {
            if (id != leavetype.Id)
            {
                return BadRequest();
            }
            _leavetypeContext.Entry(leavetype).State = EntityState.Modified;
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
        public async Task<ActionResult> DeleteLeaveTypess(int id)//delete particuar record
        {
            if (_leavetypeContext.LeaveTypess == null)
            {
                return NotFound();
            }
            var leavetype = await _leavetypeContext.LeaveTypess.FindAsync(id);
            if (leavetype == null)
            {
                return NotFound();

            }
            _leavetypeContext.LeaveTypess.Remove(leavetype);
            await _leavetypeContext.SaveChangesAsync();

            return Ok();
        }
    }


}

