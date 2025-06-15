project:
  name: "Farlo Insight"
  description: >
    Farlo Insight, yapay zeka destekli, konum bazlı coğrafi analizler ve kültürel içgörüler sağlayan modern bir mikroservis tabanlı sistemdir.
    Harita üzerinden seçilen koordinatlara göre OpenAI GPT-4 entegrasyonu ile gerçek zamanlı içerikler üretir.

sections:

  - title: "🚀 Canlı Demo"
    content: |
      🔗 Demo sayfası yakında yayında olacak...

  - title: "🧠 Proje Özeti"
    content: |
      Kullanıcı harita üzerinden bir konum seçtiğinde aşağıdaki mikroservis süreci tetiklenir:

      📍 Koordinat Seçildi  
        ↓  
      🌐 GeoDataService → Seçilen koordinata göre iklim, bitki örtüsü ve yükseklik gibi verileri üretir.  
        ↓  
      🤖 AIService → OpenAI GPT-4 kullanarak detaylı coğrafi analiz oluşturur.  
        ↓  
      🎭 CultureService → Aynı verilerle kültürel bir analiz üretir.  
        ↓  
      🧾 InsightService → AI ve kültürel içerikleri veritabanına kaydeder.  
        ↓  
      🖥️ Frontend → Kullanıcı bu analiz geçmişine ulaşabilir.

  - title: "⚙️ Kullanılan Teknolojiler"
    content: |
      ### 🌐 Backend
      - ASP.NET Core 8
      - Clean Architecture
      - Entity Framework Core
      - PostgreSQL
      - MassTransit + RabbitMQ (Event-driven yapı)
      - Docker & Docker Compose

      ### 🧠 Yapay Zeka
      - OpenAI GPT-4 API
      - Gerçek zamanlı içerik üretimi (coğrafi + kültürel)

      ### 🖥️ Frontend
      - React + TypeScript
      - Vite
      - Tailwind CSS
      - React Leaflet (Harita)
      - Axios

  - title: "🖼️ Ekran Görüntüleri"
    content: |
      - 🏠 Ana Sayfa:  
        ![Home](https://github.com/user-attachments/assets/9c1573f0-3b10-4cdb-b7e4-efd26ecc71b6)

      - 🗺️ Harita Sayfası:  
        ![Map](https://github.com/user-attachments/assets/17323092-ef1a-4660-982c-3495a5366519)

      - 🤖 AI Analizleri:  
        ![AI](https://github.com/user-attachments/assets/a1ce2bdd-c75e-4e00-89b7-6217188f0f5c)

      - 🎭 Kültürel İçerikler:  
        ![Culture](https://github.com/user-attachments/assets/7e9a8b90-7b65-436f-ade8-6c675d6f0ddf)

      - 📋 Listeleme Sayfası:  
        ![List](https://github.com/user-attachments/assets/a9fddcad-1d24-4600-bdcb-b07133d9d742)

  - title: "📂 Proje Yapısı"
    content: |
      Farlo/
      ├── Farlo.GeoDataService
      ├── Farlo.AIService
      ├── Farlo.CultureService
      ├── Farlo.InsightService
      ├── Farlo.InsightViewer (Frontend)
      ├── docker-compose.yml
      └── README.md

  - title: "📌 Katkıda Bulunmak"
    content: |
      Bu projeyi geliştirmek istiyorsan pull request gönderebilir veya issue oluşturabilirsin.
      Yeni özellikler, hata düzeltmeleri ya da öneriler her zaman memnuniyetle karşılanır. 🙌

  - title: "📄 Lisans"
    content: |
      Bu proje MIT lisansı ile yayınlanmıştır.

  - title: "👨‍💻 Geliştirici"
    content: |
      **Zeki Erdem Sincer**  
      Fırat Üniversitesi – Yazılım Mühendisliği
