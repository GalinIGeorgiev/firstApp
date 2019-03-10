using Microsoft.AspNetCore.Builder;

namespace FirstApp.Web.Middlewares
{
    public static class SeedDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedDataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
