using BookingHotelsAPI.Models;
using System.Security.Claims;

namespace BookingHotelsAPI.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(User user);
    }
}
