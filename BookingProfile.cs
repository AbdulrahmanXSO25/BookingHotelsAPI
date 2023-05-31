using AutoMapper;
using BookingHotelsAPI.Dtos;
using BookingHotelsAPI.Models;

namespace BookingHotelsAPI
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingToReturnDto>()
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.CheckInDate, opt => opt.MapFrom(src => src.CheckInDate.ToString("dd, MMM, yy")))
                .ForMember(dest => dest.CheckOutDate, opt => opt.MapFrom(src => src.CheckOutDate.ToString("dd, MMM, yy")));
        }
    }
}
