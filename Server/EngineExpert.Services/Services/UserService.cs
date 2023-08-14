using EngineExpert.Core.DtoModels;
using EngineExpert.Data;
using EngineExpert.Data.Models;
using EngineExpert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EngineExpert.Services.Services
{
    public class UserService : IUserService
    {
        private readonly EngineExpertDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService(EngineExpertDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<BaseResponseModel> LoginAsync(LoginModelRequest request)
        {
            var username = request.Username;
            var password = request.Password;

            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
                    (x.Username == username || x.Email == username)
                    && x.Password == GetHashString(password));
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, username),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                };

                foreach (var role in user.Roles)
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.Name));

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new BaseResponseModel
                {
                    IsOk = true,
                    Message = tokenHandler.WriteToken(token),
                };
            }
            else
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = "Invalid username/email or password"
                };
            }
        }

        public async Task<BaseResponseModel> RegisterAsync(RegisterModelRequest request)
        {
            var doesExist = await _dbContext.Users.AnyAsync(x => x.Username == request.Email
                    || x.Email == request.Email);
            if (doesExist)
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = "A user with the provided username/email already exists"
                };

            if (request.Username.Length < 8 || !request.Username.Any(char.IsLetter))
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = "Username/email should be at least 8 characters long and should contain letters"
                };
            }

            if (!IsValidEmail(request.Email))
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = "Invalid email provided"
                };
            }

            if (request.Password.Length < 8 || !request.Username.Any(char.IsLetter))
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = "Password should be at least 8 characters long and should contain letters"
                };
            }

            await _dbContext.AddAsync(new User
            {
                Username = request.Username,
                Password = GetHashString(request.Password),
                Email = request.Email,
                CreatedAt = DateTime.Now,
            });

            return new BaseResponseModel
            {
                IsOk = true,
                Message = "Successfully registered user!"
            };
        }

        private byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        //public async Task<bool> ForgotPasswordAsync(string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}