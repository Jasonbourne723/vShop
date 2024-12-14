
namespace vShop.Apps.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (FluentValidation.ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Message = "Validation error occurred.",
                    Errors = ex.Errors.Select(e => new
                    {
                        e.PropertyName,
                        e.ErrorMessage
                    })
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    Message = "An unexpected error occurred.",
                    Details = ex.Message // 可视需求决定是否返回详细信息
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
