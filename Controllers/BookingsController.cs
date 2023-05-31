using AutoMapper;
using BookingHotelsAPI.Dtos;
using BookingHotelsAPI.Interfaces;
using BookingHotelsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingHotelsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _bookingService = bookingService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> CreateBooking(BookingDto bookingDto)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            // Create a new booking using the booking service
            await _bookingService.CreateBooking(bookingDto, email);

            return Ok("Booking created successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsForUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (email == null)
            {
                return NotFound();
            }

            var bookings = _unitOfWork.BookingRepository.GetByUserEmail(email);

            if (bookings == null)
            {
                return NotFound();
            }

            var bookingDtos = _mapper.Map<IList<BookingToReturnDto>>(bookings);

            return Ok(bookingDtos);
        }
    }

}
