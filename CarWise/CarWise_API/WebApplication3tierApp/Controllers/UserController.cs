using _2DataAccessLayer.Services;
using _3BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3tierApp.Models;

namespace WebApplication3tierApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : BaseController
    {

        private readonly IUserService _UserService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService UserService, ILogger<UserController> logger)
        {
            _UserService = UserService;
            _logger = logger;
        }

        [HttpGet("login", Name = "GetUser")]
        public async Task<UserDto?> Login(string UserEmail, string UserPassword)
        {
            var result = await _UserService.Login(UserEmail, UserPassword);
            return result?.ToUserDto();
        }

        [HttpPost, Route("register")]
        public async Task<UserDto?> Register([FromBody] UserDto requestDto)
        {
            var UserModel = requestDto.ToUserModel();
            var result =  await _UserService.RegisterUser(UserModel);
            return result?.ToUserDto();
        }
    }
}
