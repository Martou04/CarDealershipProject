namespace CarDealershipSystem.WebAPI
{
    using CarDealershipSystem.Web.Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Data.Interfaces;
    using Web.Infrastructure.Extensions;
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<CarDealershipDbContext>(opt =>
                    opt.UseSqlServer(connectionString));

            builder.Services.AddApplicationServices(typeof(IStatisticsService));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("CarDealershipSystem", policyBuilder =>
                {
                    policyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("CarDealershipSystem");

            app.Run();
        }
    }
}