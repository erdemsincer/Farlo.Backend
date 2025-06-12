FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/Services/Farlo.GeoDataService/Farlo.GeoData.API

# Farlo.GeoData.API.csproj burada
COPY Services/Farlo.GeoDataService/Farlo.GeoData.API/Farlo.GeoData.API.csproj .

# Diðer projeleri eski ProjectReference yoluna göre yerleþtiriyoruz
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts
COPY Services/Farlo.GeoDataService/Farlo.GeoData.Application ../../Farlo.GeoData.Application
COPY Services/Farlo.GeoDataService/Farlo.GeoData.Domain ../../Farlo.GeoData.Domain
COPY Services/Farlo.GeoDataService/Farlo.GeoData.Infrastructure ../../Farlo.GeoData.Infrastructure

# Restore iþlemi artýk eski yollarla uyumlu olur
RUN dotnet restore

# Tüm kaynaklarý al
WORKDIR /src
COPY . .

# Build & Publish
WORKDIR /src/Services/Farlo.GeoDataService/Farlo.GeoData.API
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.GeoData.API.dll"]
