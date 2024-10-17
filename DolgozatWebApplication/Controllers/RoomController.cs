using DolgozatWebApplication.Entities;
using DolgozatWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DolgozatWebApplication.Controllers
{
    public class RoomController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class RoomsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;

            public RoomsController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
            {
                return await _context.Rooms.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Room>> GetRoom(int id)
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null) return NotFound();
                return room;
            }

            [HttpPost]
            public async Task<ActionResult<Room>> PostRoom(Room room)
            {
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetRoom), new { id = room.Id }, room);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutRoom(int id, Room room)
            {
                if (id != room.Id) return BadRequest();

                _context.Entry(room).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(id)) return NotFound();
                    throw;
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRoom(int id)
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null) return NotFound();

                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool RoomExists(int id) => _context.Rooms.Any(e => e.Id == id);
        }

    }
}
