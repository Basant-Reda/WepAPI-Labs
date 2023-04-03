using System.IdentityModel.Tokens.Jwt;
using Identity.BL;
using Identity.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace Identity.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region DataBase

            var connectionString = builder.Configuration.GetConnectionString("EmployeesDb");
            builder.Services.AddDbContext<EmployeesContext>(options =>
                options.UseSqlServer(connectionString));

            #endregion
            #region default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion  
            #region Identity Manager

            builder.Services.AddIdentity<Employee, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 4;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<EmployeesContext>();

            #endregion
            builder.Services.AddScoped<IEmployeesManager, EmployeesManager>();

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Cool";
                options.DefaultChallengeScheme = "Cool";
            })
                .AddJwtBearer("Cool", options =>
                {
                    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? "";
                    var secretKyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var securityKey = new SymmetricSecurityKey(secretKyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = securityKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAdminsOnly",
                    builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));

                options.AddPolicy("AllowAdminsAndUsersOnly",
                    builder => builder.RequireClaim(ClaimTypes.Role, "Admin", "User"));
            });

            #endregion

            var app = builder.Build();

            #region middlewares
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}