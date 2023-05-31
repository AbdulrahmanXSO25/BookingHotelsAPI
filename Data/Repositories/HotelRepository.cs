using BookingHotelsAPI.Interfaces;
using BookingHotelsAPI.Models;

namespace BookingHotelsAPI.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public Hotel GetById(int id)
        {
            return _context.Hotels.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public void Delete(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }
    }
}
