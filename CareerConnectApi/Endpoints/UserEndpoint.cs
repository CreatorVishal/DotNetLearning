
//using CareerConnectApi.Data;
//using CareerConnectApi.DTOs;
//using CareerConnectApi.Models;
//using CareerConnectApi.Services;
//using Microsoft.EntityFrameworkCore;
//using System.Net;

//namespace CareerConnectApi.Endpoints
//{
//    public static class UserEndpoint
//    {
//        public static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
//        {
//            var users = endpoints.MapGroup("/users");

//            users.MapPost("/register",

//async (

//AppDbContext db,

//RegisterDto dto

//) =>
//{

//    var user = new User
//    {

//        Name = dto.Name,

//        Email = dto.Email,

//        PasswordHash = dto.Password,

       

//    };

//    db.Users.Add(user);

//    await db.SaveChangesAsync();

//    return Results.Ok(user);

//});
//            users.MapPost("/login",

//async (

//AppDbContext db,

//LoginDto dto,

//JwtService jwtService

//) =>
//{

//    var user = await db.Users

//    .FirstOrDefaultAsync(

//    u => u.Email == dto.Email);

//    if (user is null)

//        return Results.BadRequest(

//        "User Not Found");

//    if (user.PasswordHash

//    != dto.Password)

//        return Results.BadRequest(

//        "Wrong Password");

//    //var token =

//    //jwtService.GenerateToken(user);

//    return Results.Ok(

//    new
//    {

//        Token = token

//    });

//});






//        }

//    }
//}
