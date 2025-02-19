using Api.LibrosLibre.Application;
using Api.LibrosLibre.Persistence;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

string path = "/etc/secrets/firebase-config.json";//"../Api.LibrosLibre.Application/firebase-config.json"

var builder = WebApplication.CreateBuilder(args);
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(path) // Agrega tu JSON de credenciales
});

// Configurar la autenticación JWT con Firebase
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/book-change-api";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/book-change-api",
            ValidateAudience = true,
            ValidAudience = "book-change-api",
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

