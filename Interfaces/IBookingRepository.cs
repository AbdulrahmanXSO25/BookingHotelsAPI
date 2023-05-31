using BookingHotelsAPI.Models;

namespace BookingHotelsAPI.Interfaces
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        IEnumerable<Booking> GetAll();
        Booking GetById(int id);
        IEnumerable<Booking> GetByUserEmail(string email);
    }
}
