using EngineExpert.Core.DtoModels;

namespace EngineExpert.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponseModel> LoginAsync(LoginModelRequest request);

        Task<BaseResponseModel> RegisterAsync(RegisterModelRequest request);

        Task<BaseResponseModel> ConfirmAccountAsync(ConfirmAccountModelRequest request);

        Task<BaseResponseModel> ForgottenPasswordAsync(ForgottenEmailModelRequest request);

        Task<BaseResponseModel> ResetPasswordAsync(ResetPasswordModelRequest request);
    }
}