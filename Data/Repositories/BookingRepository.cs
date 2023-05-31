using BookingHotelsAPI.Interfaces;
using BookingHotelsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHotelsAPI.Data.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings.Include(h => h.Hotel).ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Booking> GetByUserEmail(string email)
        {
            return _context.Bookings.Include(h => h.Hotel).Where(b => b.Email == email).ToList();
        }
    }
}
