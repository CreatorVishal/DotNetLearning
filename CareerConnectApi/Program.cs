using CareerConnectApi.Data;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Middlewares;
using CareerConnectApi.Services;
using Microsoft.EntityFrameworkCore;
using CareerConnectApi.Models;
using CareerConnectApi.Endpoints;

namespace CareerConnectApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddScoped<ICompanyService,CompanyService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<TimingMiddleware>();

            //Custom Middleware
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine($"Method : {context.Request.Method}");
            //    Console.WriteLine($"Path : {context.Request.Path}");
            //    Console.WriteLine($"QueryString  : {context.Request.QueryString}");
            //    Console.WriteLine($"Scheme: {context.Request.Scheme}");

            //    await next();
            //    // next = next middleware ka RequestDelegate

            //    Console.WriteLine("1st Response ");
            //    Console.WriteLine($"Status Code : {context.Response.StatusCode}");
            //});
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("2nd Request Aayi");

            //    await next();

            //    Console.WriteLine("2nd Response ");
            //});
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("3rd Request Aayi");

            //    await next();

            //    Console.WriteLine("3rd Response ");
            //});

            //app.UseWhen(
            //    context => context.Request.Path == "/testing1", branch =>
            //    {
            //        branch.Use(async (context, next) =>
            //        {
            //            Console.WriteLine("Only for testing");
            //            await next();
            //        });

            //    });
            //------------------------------------------

            //app.Use()->Can continue pipeline
            //app.Run()->Always terminates pipeline
            //app.Map("/test", testApp =>
            //{
            //    testApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello From Test Pipeline");
            //    });
            //});
            //app.Map("/Aijobs", AiJobsApp =>
            //{
            //    AiJobsApp.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("This page is Under Maintenance");
            //    });
            //});
            // Built-in Middleware
            app.UseHttpsRedirection();
            //Security Middleware
            app.UseAuthorization();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Website Under Maintenance");
            //});
            app.MapGet("/hello", () =>
            {
                return Results.Ok("Hello from Minimal Api..");

            });
            app.MapGet("/jobs", () =>
            {
                return Results.Ok("Jobs..");
            });
            //-----------------------
            app.MapPost("/jobs", (Job job) =>
            {
                return Results.Ok(job);
            });
            app.MapCompanyEndpoints();
            app.MapUserEndpoints();
            //Endpoint Middleware
            app.MapControllers();

            app.Run();
        }
    }
}
