using MVCIntroductionApp.Middlewares;

namespace MVCIntroductionApp
{
  public static class MiddlewareExtension
  {
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app) {
      return app.UseMiddleware<RequestLoggingMiddleware>();
    }
  }
}
