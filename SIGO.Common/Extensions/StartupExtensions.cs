using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseEnvironmentPathBase(this IApplicationBuilder app)
        {
            string pathBase = Environment.GetEnvironmentVariable("PathBase");
            if (!string.IsNullOrWhiteSpace(pathBase))
            {
                app.UsePathBase(pathBase);
                app.Use((context, next) =>
                {
                    context.Request.PathBase = pathBase;
                    return next();
                });
            }
            return app;
        }
    }
}
