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
        private readonly IEmailService _emailService;

        public UserService(EngineExpertDbContext dbContext,
            IConfiguration configuration,
            IEmailService emailService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<BaseResponseModel> LoginAsync(LoginModelRequest request)
        {
            var username = request.Username;
            var password = request.Password;

            var user = await _dbContext.Users.Where(x =>
                     (x.Username == username || x.Email == username)
                     && x.Password == GetHashString(password))
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefaultAsync();

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

                foreach (var userRole in user.UserRoles)
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.Name));

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

            if (request.Password.Length < 8 || !request.Password.Any(char.IsLetter))
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

        public async Task<BaseResponseModel> ForgottenEmailAsync(ForgottenEmailModelRequest request)
        {
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == request.RecipientEmail);
                if (user == null)
                {
                    return new BaseResponseModel
                    {
                        IsOk = true,
                        Message = $"If such a user exists, a password reset email will be send"
                    };
                }
                
                var bytes = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                    rng.GetBytes(bytes);
                var randomHash = BitConverter.ToString(bytes).Replace("-", "").ToLower();

                user.ResetPasswordToken = randomHash;
                await _dbContext.SaveChangesAsync();

                var message = $"Please click here to reset your password -> http://www.engineexpert.com/ResetPassword/{randomHash}";
                var isSent = await _emailService.SendEmailAsync(request.RecipientEmail, message);
                if (!isSent.IsOk)
                {
                    return new BaseResponseModel
                    {
                        IsOk = false,
                        Message = $"An error occurred while sending a reset password link"
                    };
                }

                return new BaseResponseModel
                {
                    IsOk = true,
                    Message = message
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = $"An error occurred while sending a reset password link"
                };
            }     
        }

        public async Task<BaseResponseModel> ResetPasswordAsync(ResetPasswordModelRequest request)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.ResetPasswordToken == request.ResetPasswordToken);
                if (user == null)
                {
                    return new BaseResponseModel
                    {
                        IsOk = false,
                        Message = $"The provided token is invalid"
                    };
                }

                if (request.Password.Length < 8 || !request.Password.Any(char.IsLetter))
                {
                    return new BaseResponseModel
                    {
                        IsOk = false,
                        Message = "Password should be at least 8 characters long and should contain letters"
                    };
                }

                user.Password = GetHashString(request.Password);
                user.ResetPasswordToken = null;
                await _dbContext.SaveChangesAsync();


                return new BaseResponseModel
                {
                    IsOk = true,
                    Message = "Password is changed successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseModel
                {
                    IsOk = false,
                    Message = $"An error occurred while changing the password"
                };
            }
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

            return sb.ToString().ToLowerInvariant();
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
    }
}