
using CareerConnectApi.Data;

namespace CareerConnectApi.Endpoints
{
    public static class UserEndpoint
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("users/", (AppDbContext context) =>
            {
                return Results.Ok(context.Users.ToList());
            }).AddEndpointFilter(async (context,next)=>
            {
                Console.WriteLine("before");
                Console.WriteLine(context.HttpContext.Request.Path);
                var result=await next(context);
                Console.WriteLine("After");
                return result;


            });

        }

    }
}
