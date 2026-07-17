using CareerConnectApi.DTOs;
using CareerConnectApi.Interfaces;

namespace CareerConnectApi.Endpoints;

public static class EmployeeEndpoint
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var employee = endpoints.MapGroup("/employee");

        // Register Employee
        employee.MapPost("/register",
        async (
            RegisterEmployeeDto dto,
            IEmployeeService service) =>
        {
            await service.RegisterAsync(dto);

            return Results.Ok(new
            {
                Message = "Employee Registered Successfully"
            });
        });

        // Login Employee
        employee.MapPost("/login",
        async (
            LoginEmployeeDto dto,
            IEmployeeService service) =>
        {
            var token = await service.LoginAsync(dto);

            if (token is null)
            {
                return Results.BadRequest(new
                {
                    Message = "Invalid Email or Password"
                });
            }

            return Results.Ok(new
            {
                Token = token
            });
        });
        employee.MapGet("/profile", () =>
        {
            return Results.Ok(new
            {
                Message = "Welcome to Employee Profile"
            });
        }).RequireAuthorization();
    }
}