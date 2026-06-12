using Serilog;
using Serilog.Sinks.PostgreSQL;
using NpgsqlTypes;
namespace Api.LibrosLibre.WebApi.Extensions
{

	public static class SerilogExtensions
	{
		public static WebApplicationBuilder AddSerilogLogging(this WebApplicationBuilder builder)
		{
			var connectionString = builder.Configuration.GetConnectionString("PostgresConnection")
				?? throw new InvalidOperationException("Connection string 'PostgresConnection' not found.");

			var columnWriters = BuildColumnWriters();

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration)   // lee appsettings.json
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.Enrich.WithThreadId()
				.WriteTo.Console()
				.WriteTo.PostgreSQL(
					connectionString: connectionString,
					schemaName: "books_free_py",
					tableName: "app_logs",
					columnOptions: columnWriters,
					needAutoCreateTable: false,
					batchSizeLimit: 50,
					period: TimeSpan.FromSeconds(5)
				)
				.CreateLogger();

			Serilog.Debugging.SelfLog.Enable(Console.Error);

			builder.Host.UseSerilog();

			return builder;
		}

		public static WebApplication UseSerilogMiddleware(this WebApplication app)
		{
			app.UseSerilogRequestLogging(options =>
			{
				options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} → {StatusCode} ({Elapsed:0.0}ms)";
				options.EnrichDiagnosticContext = EnrichFromRequest;
			});

			return app;
		}

		// ── privados ────────────────────────────────────────────────────

		private static Dictionary<string, ColumnWriterBase> BuildColumnWriters() =>
		new()
		{
			{ "message",          new RenderedMessageColumnWriter() },
			{ "message_template", new MessageTemplateColumnWriter() },
			{ "level",            new SinglePropertyColumnWriter("Level", PropertyWriteMethod.ToString) }, // ← reemplaza LevelColumnWriter
			{ "timestamp",        new TimestampColumnWriter() },
			{ "exception",        new ExceptionColumnWriter() },
			{ "properties",       new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
			{ "machine_name",     new SinglePropertyColumnWriter("MachineName") },
			{ "endpoint",         new SinglePropertyColumnWriter("Endpoint") },
			{ "request_path",     new SinglePropertyColumnWriter("RequestPath") },
			{ "user_id",          new SinglePropertyColumnWriter("UserId") },
		};

		private static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
		{
			diagnosticContext.Set("UserId", httpContext.User?.FindFirst("sub")?.Value);
			diagnosticContext.Set("RequestPath", httpContext.Request.Path);
			diagnosticContext.Set("UserAgent", httpContext.Request.Headers.UserAgent.ToString());
			diagnosticContext.Set("ClientIp", httpContext.Connection.RemoteIpAddress?.ToString());
		}
	}
}