using BankingSystemApi.Data;
using BankingSystemApi.Filters;
using BankingSystemApi.Middlewares;
using BankingSystemApi.Models;
using BankingSystemApi.Services;
using BankingSystemApi.Services.Factories;
using BankingSystemApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            //builder.Services.AddScoped<ICustomerService, PremiumCustomerService>();
            builder.Services.AddScoped<SavingAccountService>();
            builder.Services.AddScoped<CurrentAccountService>();
            builder.Services.AddScoped<SalaryAccountService>();

            builder.Services.AddScoped<AccountFactory>();
            builder.Services.AddScoped<LoggingActionFilter>();


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
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<TimingMiddleware>();
            app.Map("/admin", appbuilder =>
            {

            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
