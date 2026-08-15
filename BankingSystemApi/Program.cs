using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BankingSystemApi.Data;
using BankingSystemApi.Filters;
using BankingSystemApi.Middlewares;
using BankingSystemApi.Models;
using BankingSystemApi.Services;
using BankingSystemApi.Services.Factories;
using BankingSystemApi.Services.Interfaces;
using BankingSystemApi.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using BankingSystemApi.Data.Configurations;
using Microsoft.AspNetCore.Http.HttpResults;
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
            builder.Services.Configure<BankingSettings>(builder.Configuration.GetSection("BankingSettings"));

            //Service LifeTimes
            builder.Services.AddScoped<IAccountService, AccountService>();
            //builder.Services.AddSingleton<IAccountService,AccountService>();
            //builder.Services.AddTransient<IAccountService,AccountService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            //builder.Services.AddScoped<ICustomerService, PremiumCustomerService>();
            builder.Services.AddScoped<SavingAccountService>();
            builder.Services.AddScoped<CurrentAccountService>();
            builder.Services.AddScoped<SalaryAccountService>();

            builder.Services.AddScoped<AccountFactory>();
            //builder.Services.AddScoped<LoggingActionFilter>();
            builder.Services.AddScoped<GlobalLoggingFilter>();
            builder.Services.AddScoped<AsyncLoggingFilter>();
            builder.Services.AddScoped<ConfigurationTestService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountValidator>();
            var jwtKey = builder.Configuration["Jwt:Key"];
            var jwtIssuer = builder.Configuration["Jwt:Issuer"];
            var jwtAudience = builder.Configuration["Jwt:Audience"];

            builder.Services
                .AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtKey!)),

                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,

                        ValidateAudience = true,
                        ValidAudience = jwtAudience,

                        ValidateLifetime = true,

                        ClockSkew = TimeSpan.Zero
                    };
                   
                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("CanManageAccounts", policy =>
                {
                    policy.RequireClaim("Permission", "CanManageAccounts");
                });
            });


            // Add services to the container.

            //builder.Services.AddControllers();
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<GlobalLoggingFilter>();
                options.Filters.Add<AsyncLoggingFilter>();

            });
            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

            builder.Host.UseSerilog();

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
            //app.MapGet("config-test", (IConfiguration configuration) =>
            //{
            //    var bankName = configuration["Banking:BankName"];
            //    var currency = configuration["Banking:Currency"];
            //    var maxAmount = configuration["Banking:MaxTransactionAmount"];
            //    return Results.Ok(new
            //    {
            //        BankName = bankName,
            //        Currency = currency,
            //        MaxTransactionAmount = maxAmount
            //    });
            //});
            app.MapGet("config-test", (IOptions<BankingSettings> options) =>
            {
                var settings = options.Value;
                return Results.Ok(new
                {
                    settings.BankName,
                    settings.Currency,
                    settings.MaxTransactionAmount
                } );

            });
            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
