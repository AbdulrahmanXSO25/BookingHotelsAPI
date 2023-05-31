using BookingHotelsAPI.Models;

namespace BookingHotelsAPI.Interfaces
{
    public interface IHotelRepository
    {
        void Add(Hotel hotel);
        Hotel GetById(int id);
        IEnumerable<Hotel> GetAll();
        void Delete(Hotel hotel);
        void Update(Hotel hotel);
    }
}
