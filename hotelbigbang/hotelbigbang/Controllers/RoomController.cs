using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelbigbang.Models;
using hotelbigbang.Repositories.Services.DeptServices;
namespace hotelbigbang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomServices _context;

        public RoomController(IRoomService context)
        {
            _context = context;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
        {
            var Room = await _context.GetRoom();
            if (Room == null)
            {
                return NotFound();
            }
            return Ok(Room);
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emp>> GetRoom(int id)
        {

            var Room = await _context.GetRoom(id);

            if (Room == null)
            {
                return NotFound();
            }

            return Ok(Room);
        }

        // PUT: api/Room/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Room>> PutRoom(int id, Room Room)
        {
            return await _context.PutRoom(id, Room);
        }

        // POST: api/Room
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Room>>> PostRoom(Room Room
            )
        {
            var item = await _context.PostRoom(Room);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var Room = await _context.DeleteRoom(id);
            if (Room == null)
            {
                return NotFound();
            }
            return NoContent();
        }



    }
}
