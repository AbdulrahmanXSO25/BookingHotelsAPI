using BookingHotelsAPI.Data.Repositories;
using BookingHotelsAPI.Interfaces;

namespace BookingHotelsAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IHotelRepository _hotelRepository;
        private IBookingRepository _bookingRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IHotelRepository HotelRepository
        {
            get
            {
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository(_context);
                return _hotelRepository;
            }
        }

        public IBookingRepository BookingRepository
        {
            get
            {
                if (_bookingRepository == null)
                    _bookingRepository = new BookingRepository(_context);
                return _bookingRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
