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
    public class HotelController : ControllerBase
    {
        private readonly IHotelServices _context;

        public HotelController(ID context)
        {
            _context = context;
        }

        // GET: api/Depts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotel()
        {
            var Hotel = _context.GetHotel();
            if (Hotel == null)
            {
                return NotFound();
            }
            return Ok(Hotel);
        }



        // GET: api/Hotel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var Hotel = _context.GetHotel(id);
            if (Hotel == null)
            {
                return NotFound();
            }

            return Ok(Hotel);
        }

        // PUT: api/Hotel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> PutHotel(int id, Hotel hotel)
        {
            return Ok(await _context.PutHotel(id, hotel));
        }

        // POST: api/Hotel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Hotel>>> PostHotel(Hotel hotel)
        {
            var item = await _context.PostHotel(hotel);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // DELETE: api/Hotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var Hotel = await _context.DeleteHotel(id);
            if (Hotel== null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}