using BookingHotelsAPI.Models;

namespace BookingHotelsAPI.Dtos
{
    public class BookingDto
    {
        public int HotelId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateOnly CheckInDate { get; set; }

        public DateOnly CheckOutDate { get; set; }
    }
}
