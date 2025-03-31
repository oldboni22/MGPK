using System.Net;
using Entities;
using Entities.Exceptions.NotFound;
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
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        
                        var details = new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
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