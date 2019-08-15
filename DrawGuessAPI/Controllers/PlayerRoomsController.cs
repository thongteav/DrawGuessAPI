using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrawGuessAPI.Model;

namespace DrawGuessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerRoomsController : ControllerBase
    {
        private readonly drawguessContext _context;

        public PlayerRoomsController(drawguessContext context)
        {
            _context = context;
        }

        // GET: api/PlayerRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerRoom>>> GetPlayerRoom()
        {
            return await _context.PlayerRoom.ToListAsync();
        }

        // GET: api/PlayerRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerRoom>> GetPlayerRoom(int id)
        {
            var playerRoom = await _context.PlayerRoom.FindAsync(id);

            if (playerRoom == null)
            {
                return NotFound();
            }

            return playerRoom;
        }

        // PUT: api/PlayerRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerRoom(int id, PlayerRoom playerRoom)
        {
            if (id != playerRoom.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playerRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerRoomExists(id))
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

        // POST: api/PlayerRooms
        [HttpPost]
        public async Task<ActionResult<PlayerRoom>> PostPlayerRoom(PlayerRoom playerRoom)
        {
            _context.PlayerRoom.Add(playerRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlayerRoomExists(playerRoom.PlayerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayerRoom", new { id = playerRoom.PlayerId }, playerRoom);
        }

        // DELETE: api/PlayerRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayerRoom>> DeletePlayerRoom(int id)
        {
            var playerRoom = await _context.PlayerRoom.FindAsync(id);
            if (playerRoom == null)
            {
                return NotFound();
            }

            _context.PlayerRoom.Remove(playerRoom);
            await _context.SaveChangesAsync();

            return playerRoom;
        }

        private bool PlayerRoomExists(int id)
        {
            return _context.PlayerRoom.Any(e => e.PlayerId == id);
        }
    }
}
