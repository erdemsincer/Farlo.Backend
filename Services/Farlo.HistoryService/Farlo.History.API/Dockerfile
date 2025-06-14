# 1. Base image (.NET 8 ASP.NET Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Build image (.NET 8 SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 3. Projenin API klasörüne geç
WORKDIR /src/Services/Farlo.HistoryService/Farlo.History.API

# 4. API csproj ve baðlý projeleri tek tek kopyala
COPY Services/Farlo.HistoryService/Farlo.History.API/Farlo.History.API.csproj ./
COPY Services/Farlo.HistoryService/Farlo.History.Application ../../Farlo.History.Application
COPY Services/Farlo.HistoryService/Farlo.History.Infrastructure ../../Farlo.History.Infrastructure
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts

# 5. Restore iþlemi
RUN dotnet restore

# 6. Diðer tüm dosyalarý kopyala
WORKDIR /src
COPY . .

# 7. Publish iþlemi
WORKDIR /src/Services/Farlo.HistoryService/Farlo.History.API
RUN dotnet publish -c Release -o /app/publish

# 8. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.History.API.dll"]
