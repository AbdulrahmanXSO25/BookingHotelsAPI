using BookingHotelsAPI.Data.Repositories;
using BookingHotelsAPI.Dtos;
using BookingHotelsAPI.Interfaces;
using BookingHotelsAPI.Models;

namespace BookingHotelsAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBooking(BookingDto bookingDto, string email)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(bookingDto.HotelId);

            if (hotel == null)
            {
                // Handle case where the hotel is not found
                throw new Exception("Hotel not found.");
            }

            var numberOfNights = (int)(bookingDto.CheckOutDate.DayNumber - bookingDto.CheckInDate.DayNumber);

            if (numberOfNights <= 0)
            {
                // Handle invalid date range
                throw new Exception("Invalid date range. Check-out date should be after check-in date.");
            }

            var booking = new Booking
            {
                HotelId = bookingDto.HotelId,
                Email = email,
                Name = bookingDto.FirstName + " " + bookingDto.LastName,
                CheckInDate = bookingDto.CheckInDate.ToDateTime(TimeOnly.Parse("10:00 PM")).ToUniversalTime(),
                CheckOutDate = bookingDto.CheckOutDate.ToDateTime(TimeOnly.Parse("10:00 PM")).ToUniversalTime(),
                Price = numberOfNights * hotel.PriceOfNight
            };

            _unitOfWork.BookingRepository.Add(booking);
            _unitOfWork.SaveChanges();
        }
    }
}
