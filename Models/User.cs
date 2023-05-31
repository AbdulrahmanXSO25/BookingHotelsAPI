using Microsoft.AspNetCore.Identity;

namespace BookingHotelsAPI.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PictureUrl { get; set; }

        public string Country { get; set; }
    }
}
