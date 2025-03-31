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
                        
                        var logger = Log.Logger;
                        logger.Error(details.ToString());
                        
                        await context.Response.WriteAsync(details.ToString());
                    }
                })
            );
    }
}