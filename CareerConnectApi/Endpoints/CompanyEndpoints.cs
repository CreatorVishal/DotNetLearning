using CareerConnectApi.Data;
using CareerConnectApi.Models;
using Microsoft.EntityFrameworkCore;
using CareerConnectApi.Interfaces;
using CareerConnectApi.Filters;
using CareerConnectApi.DTOs;
using FluentValidation;
namespace CareerConnectApi.Endpoints
{
    public static class CompanyEndpoints

    {
        public static void MapCompanyEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var companies = endpoints.MapGroup("/companies");
            //endpoints.MapGet("/companies", () =>
            //{
            //    return Results.Ok("Comapnies Endpoint Working.. ");

            //});
            companies.MapGet("/", async (AppDbContext db, CancellationToken ct) =>
            {
                var companies = await db.Companies.AsNoTracking().ToListAsync(ct);
                return Results.Ok(companies);
            }).AddEndpointFilter<CompanyFilter>();

            companies.MapGet("/{id:int}", async (int id, AppDbContext db) =>
            {
                var company = await db.Companies.FindAsync(id);
                if (company is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(company);

            })
            //Second way
            .AddEndpointFilter(async (context, next) =>
             {
                 Console.WriteLine("Before");

                 var result = await next(context);

                 Console.WriteLine("After");

                 return result;
             });
            //----------------------------------------------------------
            //endpoints.MapPost("/companies", (Company company) =>
            //{
            //    return Results.Ok(company);

            //});
            //---------------------------------

            //companies.MapPost("/",async (AppDbContext db , Company company) =>
            //{
            //    db.Companies.Add(company);
            //    await db.SaveChangesAsync();
            //    return Results.Created($"/companies/{company.Id}",company);
            //});

            //---------------------------------------------------
            companies.MapPut("/{id:int}", async (int id, Company company, AppDbContext db) =>
            {
                var existingCompany = await db.Companies.FindAsync(id);
                if (existingCompany is null)
                {
                    return Results.NotFound();
                }
                existingCompany.CompanyName = company.CompanyName;
                await db.SaveChangesAsync();
                return Results.Ok(existingCompany);

            });
            //--------------------------------------------------------
            companies.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
            {
                var existCompany = await db.Companies.FindAsync(id);
                if (existCompany is null)
                {
                    return Results.NotFound("Already Null");
                }
                db.Companies.Remove(existCompany);
                await db.SaveChangesAsync();
                return Results.NoContent();

            });
            //------------------------------------------------
            //endpoints.MapGet("/companies/search", (string name) =>
            //{
            //    return Results.Ok(name);
            //});

            companies.MapGet("/search", async (string name, AppDbContext db) =>
            {
                var companies = await db.Companies.Where(c => c.CompanyName.Contains(name)).ToListAsync();
                return Results.Ok(companies);

            });
            //Multiple Query Parameter 
            companies.MapGet("/test", (string name, int page) =>
            {
                return Results.Ok($"{name}-{page}");

            });
            //-----------------------------------------------------------
            companies.MapGet("/info", (HttpContext context) =>
            {
                return Results.Ok(new
                {
                    Path = context.Request.Path,
                    Method = context.Request.Method,

                });

            });
            companies.MapGet("/host", (HttpContext context) =>
            {
                return Results.Ok(context.Request.Host);
            });
            //QueryString
            companies.MapGet("/query", (HttpContext context) =>
            {
                return Results.Ok(context.Request.QueryString);

            });
            //header
            companies.MapGet("/headers", (HttpContext context) =>
            {
                return Results.Ok(context.Request.Headers);
            });
            //client ip
            companies.MapGet("/ip", (HttpContext context) =>
            {
                var ip = context.Connection.RemoteIpAddress?.ToString();

                return Results.Ok(new
                {
                    IP = ip ?? "IP Not Available"
                });
            });
            //---------------------------------------------------------------------------------
            //ILogger
            companies.MapGet("/log", (ILogger<Program> logger) =>
            {
                logger.LogInformation("Company Endpoint Hit");
                return Results.Ok("Check console...");
            });

            companies.MapGet("/logger", (ILogger<Program> logger) =>
            {
                logger.LogInformation("Fetching Companies");
                logger.LogWarning("Warning");
                logger.LogError("Error");
                logger.LogCritical("Critical");
                return Results.Ok("Check Console");
            });
            //--------------------------------------------------------------
            companies.MapGet("/config", (IConfiguration config) =>
            {
                var company = config["CompanySettings:CompanyName"];
                var version = config["CompanySettings:Version"];
                var owner = config["CompanySettings:Owner"];
                return Results.Ok(
                    new
                    {
                        company,
                        version,
                        owner
                    });
            });
            //--------------------------------------
            companies.MapGet("/service", async (ICompanyService service) =>
            {
                var companies = await service.GetAllCompaniesAsync();
                return Results.Ok(companies);
            });
            companies.MapPost("/", async (AppDbContext db, CreateCompanyDto dto, IValidator<CreateCompanyDto> validator) =>
            {
                var validation =

await validator.ValidateAsync(dto);

                if (!validation.IsValid)
                {

                    return Results.ValidationProblem(

                    validation.ToDictionary()

                    );

                }
                var company = new Company
                {
                    CompanyName = dto.CompanyName,
                    Email = dto.Email,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false,
                    PasswordHash = "",

                };
                db.Companies.Add(company);
                await db.SaveChangesAsync();
                return Results.Ok(company);
            });
            companies.MapGet("/secure",

() =>
{

    return Results.Ok(

    "Secret Data"

    );

})

.RequireAuthorization();


        }
    }
}
