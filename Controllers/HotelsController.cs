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
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public HotelsController(IBookingService bookingService, IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _bookingService = bookingService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHotelById(int id)
        {
            var hotel = _unitOfWork.HotelRepository.GetById(id);

            if (hotel == null) { return NotFound(); }

            return Ok(hotel);
        }

        [HttpGet]
        public async Task<ActionResult> GetHotels()
        {
            var hotels = _unitOfWork.HotelRepository.GetAll();

            if (hotels == null) { return NotFound(); }

            return Ok(hotels);
        }
    }
}
