using Assets.Domain.Exceptions;

namespace Assets.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {

        private async void WriteMessage(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(message);
            logger.LogError(message);
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                WriteMessage(context, ex.StatusCode, ex.Message);

            }
            catch (Exception ex)
            {
                WriteMessage(context, 500, ex.Message);
            }
        }
    }
}
