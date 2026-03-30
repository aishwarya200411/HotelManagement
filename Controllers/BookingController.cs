using Microsoft.AspNetCore.Mvc;
using HotelManagement.Data;
using HotelManagement.Models;
using System.Linq;

namespace HotelManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            var room = _context.Rooms.Find(booking.RoomId);

            if (room == null)
                return BadRequest("Room not found");

            if (!room.IsAvailable)
                return BadRequest("Room not available");

            room.IsAvailable = false;
            booking.Status = "Confirmed";

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok("Booking successful");
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings.ToList();
            return Ok(bookings);
        }

        [HttpPost("cancel/{id}")]
        public IActionResult CancelBooking(int id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking == null)
                return NotFound("Booking not found");

            var room = _context.Rooms.Find(booking.RoomId);
            if (room != null)
            {
                room.IsAvailable = true;
            }

            booking.Status = "Cancelled";
            _context.SaveChanges();

            return Ok("Booking cancelled successfully");
        }
    }
}
