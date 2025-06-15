readme:
  title: "🌍 Farlo Insight"
  description: >
    Farlo Insight, yapay zeka destekli, konum tabanlı coğrafi ve kültürel analizler sunan modern bir mikroservis mimarili projedir.
    Harita üzerinden seçilen bir konum için OpenAI GPT-4 ile anlamlı içgörüler üretir ve kullanıcıya sunar.
    Harita → AI → İçgörü zinciriyle gerçek zamanlı analiz deneyimi!

  demo:
    status: "Yakında"
    url: null

  summary: |
    Kullanıcı harita üzerinden bir konum seçtiğinde aşağıdaki mikroservis süreci devreye girer:

      📍 Koordinat Seçildi
            ↓
      🌐 GeoDataService → İklim, bitki örtüsü, yükseklik verisi üretir.
            ↓
      🤖 AIService → GPT-4 ile coğrafi analiz oluşturur.
            ↓
      🎭 CultureService → Aynı veriden kültürel analiz üretir.
            ↓
      🧾 InsightService → Tüm içerikler veritabanına kaydedilir.
            ↓
      🖥️ Frontend → Sonuçlar kullanıcı arayüzünde gösterilir.

  technologies:
    backend:
      - ASP.NET Core 8
      - Clean Architecture
      - Entity Framework Core
      - PostgreSQL
      - MassTransit + RabbitMQ
      - Docker & Docker Compose
    ai:
      - OpenAI GPT-4 API
      - Gerçek zamanlı coğrafi ve kültürel içerik üretimi
    frontend:
      - React + TypeScript
      - Vite
      - Tailwind CSS
      - React Leaflet
      - Axios

  screenshots:
    - title: "Ana Sayfa"
      url: "https://github.com/user-attachments/assets/9c1573f0-3b10-4cdb-b7e4-efd26ecc71b6"
    - title: "Harita Sayfası"
      url: "https://github.com/user-attachments/assets/17323092-ef1a-4660-982c-3495a5366519"
    - title: "AI Analizleri"
      url: "https://github.com/user-attachments/assets/a1ce2bdd-c75e-4e00-89b7-6217188f0f5c"
    - title: "Kültürel İçerikler"
      url: "https://github.com/user-attachments/assets/7e9a8b90-7b65-436f-ade8-6c675d6f0ddf"
    - title: "Listeleme Sayfası"
      url: "https://github.com/user-attachments/assets/a9fddcad-1d24-4600-bdcb-b07133d9d742"

  structure: |
    Farlo
    ├── Farlo.GeoDataService
    ├── Farlo.AIService
    ├── Farlo.CultureService
    ├── Farlo.InsightService
    ├── Farlo.InsightViewer (Frontend)
    ├── docker-compose.yml
    └── README.md

  contribution: |
    Projeyi geliştirmek veya öneride bulunmak istersen PR (Pull Request) gönderebilir veya issue oluşturabilirsin.
    Her katkı değerlidir. 🙌

  license: MIT

  author:
    name: "Zeki Erdem Sincer"
    university: "Fırat Üniversitesi"
    department: "Yazılım Mühendisliği"
