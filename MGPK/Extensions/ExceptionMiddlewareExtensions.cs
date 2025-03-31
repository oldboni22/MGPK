using System.Net;
using Entities;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace MGPK.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandling(this WebApplication app)
    {
        app.UseExceptionHandler(_ =>
            _.Run(async  context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var details = new ErrorDetails
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            Message = "Internal server error"
                        };
                        
                        Log.Logger.Error(details.ToString());
                        
                        await context.Response.WriteAsync(details.ToString());
                    }
                })
            );
    }

    public static void ConfigureSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((_, config) => config
            .WriteTo.Console()
            .WriteTo.File("logs/.log"));
    }
}