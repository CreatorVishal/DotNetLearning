namespace CareerConnectApi.Filters;

public class CompanyFilter: IEndpointFilter
{

    public async ValueTask<object?>
        InvokeAsync(EndpointFilterInvocationContext context,EndpointFilterDelegate next)
    {

        Console.WriteLine("Before Endpoint" );

        var result = await next(context);
        Console.WriteLine("After Endpoint");
        return result;

    }

}