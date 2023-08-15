using EngineExpert.Core.DtoModels;

namespace EngineExpert.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponseModel> LoginAsync(LoginModelRequest request);

        Task<BaseResponseModel> RegisterAsync(RegisterModelRequest request);

        Task<BaseResponseModel> ForgottenEmailAsync(ForgottenEmailModelRequest request);

        Task<BaseResponseModel> ResetPasswordAsync(ResetPasswordModelRequest request);
    }
}