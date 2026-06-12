using Api.LibrosLibre.Application;
using Api.LibrosLibre.Persistence;
using Api.LibrosLibre.WebApi.Middleware;
using Api.LibrosLibre.WebApi.Extensions;
using Serilog;

Serilog.Debugging.SelfLog.Enable(Console.Error); // diagnóstico

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

Log.Error("TEST — App iniciada, probando escritura en PostgreSQL"); // prueba

app.UseMiddleware<ExcepctionHandlingMiddleware>();
app.UseSerilogMiddleware();  // ← solo una vez

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Lifetime.ApplicationStopping.Register(Log.CloseAndFlush); // flush al cerrar

app.Run();