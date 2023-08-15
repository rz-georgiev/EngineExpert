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

        [HttpPost("ConfirmAccount")]
        public async Task<BaseResponseModel> ConfirmAccount(ConfirmAccountModelRequest request)
        {
            return await _userService.ConfirmAccountAsync(request);
        }

        [HttpPost("ForgottenPassword")]
        public async Task<BaseResponseModel> ForgottenPassword(ForgottenEmailModelRequest request)
        {
            return await _userService.ForgottenPasswordAsync(request);
        }

        [HttpPost("ResetPassword")]
        public async Task<BaseResponseModel> ResetPassword(ResetPasswordModelRequest request)
        {
            return await _userService.ResetPasswordAsync(request);
        }
    }
}