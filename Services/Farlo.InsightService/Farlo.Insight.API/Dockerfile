FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 🧭 ProjectReference’lar ../../../ ile yukarı çıkıyor, o yüzden doğru yerden başlıyoruz
WORKDIR /src/Services/Farlo.InsightService/Farlo.Insight.API

# ✅ .csproj dosyasını ve bağımlı projeleri doğru şekilde kopyala
COPY Services/Farlo.InsightService/Farlo.Insight.API/Farlo.Insight.API.csproj .

COPY Services/Farlo.InsightService/Farlo.Insight.Application ../../Farlo.Insight.Application
COPY Services/Farlo.InsightService/Farlo.Insight.Infrastructure ../../Farlo.Insight.Infrastructure
COPY Services/Farlo.InsightService/Farlo.Insight.Domain ../../Farlo.Insight.Domain
COPY BuildingBlocks/Farlo.EventContracts ../../../../BuildingBlocks/Farlo.EventContracts

# 🔧 Restore işlemi artık .csproj yoluyla uyumlu
RUN dotnet restore

# 📦 Tüm kaynakları kopyala
WORKDIR /src
COPY . .

# 🛠 Yayınla
WORKDIR /src/Services/Farlo.InsightService/Farlo.Insight.API
RUN dotnet publish -c Release -o /app/publish

# 🚀 Final aşama
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Farlo.Insight.API.dll"]
