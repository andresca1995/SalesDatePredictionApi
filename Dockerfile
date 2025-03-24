# Imagen base para compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos de solución y de proyecto
COPY ApiSalesPrediction.sln ./
COPY ApiSalesPrediction/ApiSalesPrediction.csproj ApiSalesPrediction/
COPY models/models.csproj models/

# Restaurar dependencias
RUN dotnet restore

# Copiar el código fuente y compilar
COPY . .
WORKDIR /src/ApiSalesPrediction
RUN dotnet publish -c Release -o /app/publish

# Imagen base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# Exponer puertos
EXPOSE 8080
EXPOSE 443

# Configurar la URL de la aplicación dentro del contenedor
ENV ASPNETCORE_URLS=http://+:8080

# Comando de inicio
ENTRYPOINT ["dotnet", "ApiSalesPrediction.dll"]
