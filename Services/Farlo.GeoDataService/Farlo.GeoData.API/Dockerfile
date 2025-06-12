FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Services/Farlo.GeoDataService/Farlo.GeoData.API/Farlo.GeoData.API.csproj", "Farlo.GeoData.API/"]
COPY ["Services/Farlo.GeoDataService/Farlo.GeoData.Application/Farlo.GeoData.Application.csproj", "Farlo.GeoData.Application/"]
COPY ["Services/Farlo.GeoDataService/Farlo.GeoData.Infrastructure/Farlo.GeoData.Infrastructure.csproj", "Farlo.GeoData.Infrastructure/"]
COPY ["BuildingBlocks/Farlo.EventContracts/Farlo.EventContracts.csproj", "Farlo.EventContracts/"]

RUN dotnet restore "Farlo.GeoData.API/Farlo.GeoData.API.csproj"

COPY . .
WORKDIR "/src/Farlo.GeoData.API"
RUN dotnet publish "Farlo.GeoData.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.GeoData.API.dll"]
