# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and restore
COPY common.props .
COPY *.sln .
COPY src/ src/
COPY test/ test/

RUN dotnet restore

# Build
RUN dotnet publish src/PersonelYonetim.HttpApi.Host/PersonelYonetim.HttpApi.Host.csproj \
    -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080

ENTRYPOINT ["dotnet", "PersonelYonetim.HttpApi.Host.dll"]