namespace BookingHotelsAPI.Dtos
{
    public class BookingToReturnDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string HotelName { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public decimal Price { get; set; }
    }
}
