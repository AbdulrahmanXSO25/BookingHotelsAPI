namespace BookingHotelsAPI.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public string Country { get; set; }

        public decimal PriceOfNight { get; set; }
    }
}
