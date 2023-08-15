using EngineExpert.Data.Migrations;

namespace EngineExpert.Data.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ResetPasswordToken { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}