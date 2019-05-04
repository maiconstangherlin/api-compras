
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class MyAuthentication
{
    private readonly RequestDelegate _next;

    public MyAuthentication(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string token = context.Request.Headers["Authorization"];

        if (token != null && token.Equals("periodo7"))
        {
            await _next(context);
        }
        else
        {            
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Acesso negado!");
        }
    }

}

