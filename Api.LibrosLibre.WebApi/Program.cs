using Api.LibrosLibre.Application;
using Api.LibrosLibre.Persistence;
using Api.LibrosLibre.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<ExcepctionHandlingMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

