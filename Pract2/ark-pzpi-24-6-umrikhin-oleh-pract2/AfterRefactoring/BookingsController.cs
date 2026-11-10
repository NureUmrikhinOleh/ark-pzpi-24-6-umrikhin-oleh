using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingApp.Data;
using HotelBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("available-rooms")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAvailableRooms([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            if (checkIn >= checkOut)
            {
                return BadRequest("Дата заїзду повинна бути ранішою за дату виїзду.");
            }

            var occupiedRoomIds = await _context.Bookings
                .Where(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn)
                .Select(b => b.RoomId)
                .ToListAsync();

            var availableRooms = await _context.Rooms
                .Where(r => !occupiedRoomIds.Contains(r.Id))
                .Include(r => r.Hotel)
                .ToListAsync();

            return Ok(availableRooms);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking booking)
        {
            if (booking.CheckInDate >= booking.CheckOutDate)
            {
                return BadRequest("Некоректні дати бронювання.");
            }

            if (await IsRoomOccupied(booking)) // замість змінної isOccupied
            {
                return BadRequest("Ця кімната вже заброньована на вибрані дати.");
            }

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }

        // метод-запит замість тимчасової змінної
        private Task<bool> IsRoomOccupied(Booking booking)
        {
            return _context.Bookings.AnyAsync(b =>
                b.RoomId == booking.RoomId &&
                b.CheckInDate < booking.CheckOutDate &&
                b.CheckOutDate > booking.CheckInDate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound($"Бронювання з ID {id} не знайдено.");
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await _context.Bookings
                .Include(b => b.Client)
                .Include(b => b.Room)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null) return NotFound();
            return Ok(booking);
        }
    }
}