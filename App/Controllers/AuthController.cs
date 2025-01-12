using Business.DTOs.Account;
using Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            await _userService.Register(dto);
            return Ok();

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {

            await _userService.Login(dto);
            return Ok();

        }
    }
}
