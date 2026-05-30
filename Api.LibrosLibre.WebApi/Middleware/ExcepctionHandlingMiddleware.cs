using System.Text.Json;
using Api.LibrosLibre.Domain.Common;

namespace Api.LibrosLibre.WebApi.Middleware
{
	public class ExcepctionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExcepctionHandlingMiddleware> _logger;

		public ExcepctionHandlingMiddleware(RequestDelegate next, ILogger<ExcepctionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			_logger.LogError(exception, "An unhandled exception has occurred.");
			context.Response.ContentType = "application/json";
			var response = new ErrorResponse();	

			switch (exception)
			{
				case Application.Exceptions.NotFoundException notFoundEx:
					context.Response.StatusCode = StatusCodes.Status404NotFound;
					response.StatusCode = StatusCodes.Status404NotFound;
					response.Message = notFoundEx.Message;
					break;
				case Application.Exceptions.RepositoryException repoEx:
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					response.StatusCode = StatusCodes.Status500InternalServerError;
					response.Message = repoEx.Message;
					break;
				default:
					context.Response.StatusCode = StatusCodes.Status500InternalServerError;
					response.Message = "An unexpected error occurred.";
					break;
			}

			response.StackTrace = exception.StackTrace;
			var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			});

			await context.Response.WriteAsync(jsonResponse);

		}
	}
}