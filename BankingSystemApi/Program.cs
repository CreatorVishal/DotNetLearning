using BankingSystemApi.Data;
using Microsoft.Extensions.Options;
using BankingSystemApi.Models;

using BankingSystemApi.Services;
using BankingSystemApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace BankingSystemApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.Configure<BankSettings>(builder.Configuration.GetSection("BankSettings"));

            //Service LifeTimes
            builder.Services.AddScoped<IAccountService,AccountService>();
            //builder.Services.AddSingleton<IAccountService,AccountService>();
            //builder.Services.AddTransient<IAccountService,AccountService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            Console.WriteLine($"Current Environment: {app.Environment.EnvironmentName}");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
