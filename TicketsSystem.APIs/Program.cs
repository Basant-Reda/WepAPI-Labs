
using Microsoft.EntityFrameworkCore;
using TicketsSystem.BL;
using TicketsSystem.DAL;

namespace TicketsSystem.APIs
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
            #region Database

            var connectionString = builder.Configuration.GetConnectionString("TicketsSystemDb");
            builder.Services.AddDbContext<TicketsSystemContext>(options =>
                options.UseSqlServer(connectionString));

            #endregion

            #region Repos

            builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Managers

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}