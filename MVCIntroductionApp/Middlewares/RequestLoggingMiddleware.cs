
using System.Diagnostics;

namespace MVCIntroductionApp.Middlewares
{
  public class RequestLoggingMiddleware : IMiddleware
  {
    private readonly ILogger _logger;

    public RequestLoggingMiddleware(ILogger<RequestLoggingMiddleware> logger)
    {
      this._logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

      _logger.LogInformation("Request Logging");
      Stopwatch sp = Stopwatch.StartNew();

      await next(context); // controller gider 

      // Response
      _logger.LogInformation($"Response -> Loggin Stop {sp.ElapsedMilliseconds}");

    }
  }
}
