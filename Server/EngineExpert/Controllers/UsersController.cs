using EngineExpert.Core.DtoModels;
using EngineExpert.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EngineExpert.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<BaseResponseModel> Login(LoginModelRequest request)
        {
            return await _userService.LoginAsync(request);
        }

        [HttpPost("Register")]
        public async Task<BaseResponseModel> Register(RegisterModelRequest request)
        {
            return await _userService.RegisterAsync(request);
        }
    }
}