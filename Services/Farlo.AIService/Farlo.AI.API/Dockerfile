FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 1. Doðru klasöre geç — burada .csproj yollarý `../../../` gibi yukarý çýkacak
WORKDIR /src/Services/Farlo.AIService/Farlo.AI.API

# 2. Sadece .csproj dosyasýný deðil, ona göre baðýmlý projeleri de yukarý klasörlere uygun þekilde kopyala
COPY Services/Farlo.AIService/Farlo.AI.API/Farlo.AI.API.csproj .

COPY Services/Farlo.AIService/Farlo.AI.Application ../../Farlo.AI.Application
COPY Services/Farlo.AIService/Farlo.AI.Infrastructure ../../Farlo.AI.Infrastructure
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts

# 3. restore yap (þimdi referans yollarý uyumlu oldu)
RUN dotnet restore

# 4. tüm kaynaklarý kopyala
WORKDIR /src
COPY . .

# 5. publish
WORKDIR /src/Services/Farlo.AIService/Farlo.AI.API
RUN dotnet publish -c Release -o /app/publish

# 6. final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.AI.API.dll"]
