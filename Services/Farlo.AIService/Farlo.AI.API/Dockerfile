FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 1. Do�ru klas�re ge� � burada .csproj yollar� `../../../` gibi yukar� ��kacak
WORKDIR /src/Services/Farlo.AIService/Farlo.AI.API

# 2. Sadece .csproj dosyas�n� de�il, ona g�re ba��ml� projeleri de yukar� klas�rlere uygun �ekilde kopyala
COPY Services/Farlo.AIService/Farlo.AI.API/Farlo.AI.API.csproj .

COPY Services/Farlo.AIService/Farlo.AI.Application ../../Farlo.AI.Application
COPY Services/Farlo.AIService/Farlo.AI.Infrastructure ../../Farlo.AI.Infrastructure
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts

# 3. restore yap (�imdi referans yollar� uyumlu oldu)
RUN dotnet restore

# 4. t�m kaynaklar� kopyala
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
