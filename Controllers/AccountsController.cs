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
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public AccountsController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (email == null)
                return NotFound();

            var user = await _userManager.FindByNameAsync(email.Split('@')[0]);

            var token = _jwtService.CreateToken(user);

            return Ok(
            new
            {
                Email = user?.Email,
                Token = token,
                UserName = user?.UserName
            });
        }

        [HttpGet("check-email-exists")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            var user = await _userManager.FindByNameAsync(email.Split('@')[0]);

            if (user != null)
            {
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                PictureUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png",
                Country = model.Country
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = _jwtService.CreateToken(user);
                return Ok(new { UserName = user.UserName, Email = user!.Email, Token = token });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var token = _jwtService.CreateToken(user);
                return Ok(new { UserName = user.UserName, Email = user!.Email, Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
