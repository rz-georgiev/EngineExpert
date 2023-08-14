using System.ComponentModel.DataAnnotations;

namespace EngineExpert.Core.DtoModels
{
    public class RegisterModelRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
