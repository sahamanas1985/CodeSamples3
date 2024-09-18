
namespace CustomMiddlewareDemo
{
   
    public class CustomErrorHandlerMw
    {
        private readonly RequestDelegate _next;

        public CustomErrorHandlerMw(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {                
                httpContext.Session.SetString("errormsg", ex.Message);
                httpContext.Session.SetString("stacktrace", ex.StackTrace.ToString());
                httpContext.Response.Redirect ("/Error");
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomErrorHandlerMwExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandlerMw(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorHandlerMw>();
        }
    }
}
