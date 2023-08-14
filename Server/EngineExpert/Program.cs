
using EngineExpert.Data;
using EngineExpert.Services.Interfaces;
using EngineExpert.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace EngineExpert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add JWT authentication to the services
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://your-auth-server.com/";
                    options.Audience = "EngineExpert";
                    //options.SigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));
                });

            var connectionString = "Server=MYSQL5048.site4now.net;Database=db_a558e2_engexp;Uid=a558e2_engexp;Pwd=engexp1234";
            // Add Pomelo Entity Framework Core to the services
            builder.Services.AddDbContext<EngineExpertDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddTransient<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}