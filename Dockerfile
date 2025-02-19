# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos de solución y los archivos de proyecto
COPY ["*.sln", "./"]
COPY ["Api.LibrosLibre.Application/Api.LibrosLibre.Application.csproj", "Api.LibrosLibre.Application/"]
COPY ["Api.LibrosLibre.Domain/Api.LibrosLibre.Domain.csproj", "Api.LibrosLibre.Domain/"]
COPY ["Api.LibrosLibre.Persistence/Api.LibrosLibre.Persistence.csproj", "Api.LibrosLibre.Persistence/"]
COPY ["Api.LibrosLibre.WebApi/Api.LibrosLibre.WebApi.csproj", "Api.LibrosLibre.WebApi/"]

# Restaurar todas las dependencias
RUN dotnet restore

# Copiar todo el código fuente después de restaurar
COPY . .

# Construir la aplicación
WORKDIR /app/Api.LibrosLibre.WebApi
RUN dotnet publish -c Release -o /publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

# Exponer el puerto
EXPOSE 8080
ENTRYPOINT ["dotnet", "Api.LibrosLibre.WebApi.dll"]
