using EngineExpert.Core.DtoModels;

namespace EngineExpert.Services.Interfaces
{
    public interface IEmailService
    {
        Task<BaseResponseModel> SendEmailAsync(string receipient, string message);
    }
}