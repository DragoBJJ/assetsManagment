using System.Diagnostics;

namespace Assets.API.Middlewares
{
    public class TotalExecutedTimeMiddleware(ILogger<TotalExecutedTimeMiddleware> logger) : IMiddleware
    {
        private readonly double MillisecondsPerSecond = 1000.0;
        private readonly double DelayTime = 4;
        private double ConvertToSeconds(double time)
        {
            return time / MillisecondsPerSecond;
        }

        private (string?, string) GetDetails(HttpContext context)
        {
            var requestPath = context.Request.Path.Value;
            var requestMethod = context.Request.Method;

            return (requestPath, requestMethod);
        }

        private async Task SimulationDelay(double delayTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var currentTime = Stopwatch.StartNew();
            try
            {
               /* await SimulationDelay(DelayTime);*/
                await next.Invoke(context);
            }
            finally
            {
                currentTime.Stop();
                var (requestPath, requestMethod) = GetDetails(context);
                var totalExecutedTime = ConvertToSeconds(currentTime.ElapsedMilliseconds);

                if (totalExecutedTime >= DelayTime)
                {
                    logger.LogInformation($"Method: {requestMethod}, Path: {requestPath} executed in {totalExecutedTime} seconds");
                }


            }
        }
    }
}
