using BookingHotelsAPI.Dtos;

namespace BookingHotelsAPI.Interfaces
{
    public interface IBookingService
    {
        Task CreateBooking(BookingDto bookingDto, string email);
    }
}
