FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Node.js yükle (abp install-libs için)
RUN apt-get update && apt-get install -y nodejs npm

# ABP CLI yükle
RUN dotnet tool install -g Volo.Abp.Cli
ENV PATH="$PATH:/root/.dotnet/tools"

COPY common.props .
COPY *.sln .
COPY src/ src/
COPY test/ test/

RUN dotnet restore

# ABP libs yükle
RUN cd src/PersonelYonetim.HttpApi.Host && abp install-libs

RUN dotnet publish src/PersonelYonetim.HttpApi.Host/PersonelYonetim.HttpApi.Host.csproj \
    -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 8080
ENTRYPOINT ["dotnet", "PersonelYonetim.HttpApi.Host.dll"]