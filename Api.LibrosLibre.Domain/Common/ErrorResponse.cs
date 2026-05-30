namespace Api.LibrosLibre.Domain.Common
{
	public class ErrorResponse
	{
		public int StatusCode { get; set; }
		public string Message { get; set; } = string.Empty;
		public Dictionary<string, string[]>? Errors { get; set; }
		public string? StackTrace { get; set; }
	}
}