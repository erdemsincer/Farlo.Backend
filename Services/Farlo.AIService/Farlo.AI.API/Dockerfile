# 1. Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# 2. Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeleri doðru klasörlerden alýyoruz
COPY ["Services/Farlo.AIService/Farlo.AI.API/Farlo.AI.API.csproj", "Farlo.AI.API/"]
COPY ["Services/Farlo.AIService/Farlo.AI.Application/Farlo.AI.Application.csproj", "Farlo.AI.Application/"]
COPY ["Services/Farlo.AIService/Farlo.AI.Infrastructure/Farlo.AI.Infrastructure.csproj", "Farlo.AI.Infrastructure/"]
COPY ["BuildingBlocks/Farlo.EventContracts/Farlo.EventContracts.csproj", "Farlo.EventContracts/"]

# NuGet restore iþlemi
RUN dotnet restore "Farlo.AI.API/Farlo.AI.API.csproj"

# Tüm kaynaklarý kopyala
COPY . .

# Build & publish
WORKDIR "/src/Farlo.AI.API"
RUN dotnet publish "Farlo.AI.API.csproj" -c Release -o /app/publish

# 3. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.AI.API.dll"]
