using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDetailSystem.Models;

namespace UserDetailSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/UserTbs")]
    public class UserTbsController : Controller
    {
        private readonly UserDBContext _context;

        public UserTbsController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/UserTbs
        [HttpGet]
        public IEnumerable<UserTb> GetUserTb()
        {
            return _context.UserTb;
        }

        // GET: api/UserTbs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTb = await _context.UserTb.SingleOrDefaultAsync(m => m.UserId == id);

            if (userTb == null)
            {
                return NotFound();
            }

            return Ok(userTb);
        }

        // PUT: api/UserTbs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTb([FromRoute] int id, [FromBody] UserTb userTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTb.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userTb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTbExists(id))
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

        // POST: api/UserTbs
        [HttpPost]
        public async Task<IActionResult> PostUserTb([FromBody] UserTb userTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserTb.Add(userTb);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTbExists(userTb.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserTb", new { id = userTb.UserId }, userTb);
        }

        // DELETE: api/UserTbs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTb([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTb = await _context.UserTb.SingleOrDefaultAsync(m => m.UserId == id);
            if (userTb == null)
            {
                return NotFound();
            }

            _context.UserTb.Remove(userTb);
            await _context.SaveChangesAsync();

            return Ok(userTb);
        }

        private bool UserTbExists(int id)
        {
            return _context.UserTb.Any(e => e.UserId == id);
        }
    }
}