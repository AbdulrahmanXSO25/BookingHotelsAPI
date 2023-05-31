using Microsoft.AspNetCore.Identity;

namespace BookingHotelsAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal Price { get; set; }
    }
}
