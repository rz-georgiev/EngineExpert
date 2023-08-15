namespace EngineExpert.Core.DtoModels
{
    public class ResetPasswordModelRequest
    {
        public string ResetPasswordToken { get; set; }

        public string Password { get; set; }
    }
}
