# 1. Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 2. Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Doðru konuma geç
WORKDIR /src/Services/Farlo.CultureService/Farlo.Culture.API

# 3. .csproj dosyalarýný ve baðýmlý projeleri kopyala
COPY Services/Farlo.CultureService/Farlo.Culture.API/Farlo.Culture.API.csproj .
COPY Services/Farlo.CultureService/Farlo.Culture.Application ../../Farlo.Culture.Application
COPY Services/Farlo.CultureService/Farlo.Culture.Infrastructure ../../Farlo.Culture.Infrastructure
COPY Services/Farlo.CultureService/Farlo.Culture.Domain ../../Farlo.Culture.Domain
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts

# 4. Restore iþlemi
RUN dotnet restore

# 5. Kaynak kodlarýn tamamýný kopyala
WORKDIR /src
COPY . .

# 6. Build + publish
WORKDIR /src/Services/Farlo.CultureService/Farlo.Culture.API
RUN dotnet publish -c Release -o /app/publish

# 7. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.Culture.API.dll"]
