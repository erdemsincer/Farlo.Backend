# 🌍 Farlo Insight

Farlo Insight, yapay zeka destekli, konum bazlı coğrafi analizler ve kültürel içgörüler sağlayan modern bir mikroservis tabanlı sistemdir. Harita üzerinden seçilen koordinatlara göre OpenAI entegrasyonu ile detaylı analizler üretir ve kullanıcıya sunar.

## 🚀 Canlı Demo

🔗 Demo sayfası yakında...

---

## 🧠 Proje Özeti

Kullanıcı, harita üzerinden bir nokta seçer. Bu nokta sistemde aşağıdaki süreci tetikler:

1. **GeoDataService** → Seçilen koordinata göre iklim, bitki örtüsü, yükseklik gibi verileri üretir.
2. **AIService** → OpenAI kullanarak genel coğrafi analiz oluşturur.
3. **CultureService** → Aynı verilerle kültürel bir metin üretir.
4. **InsightService** → Bu iki çıktıyı ayrı olarak veritabanına kaydeder.
5. **Frontend** → Kullanıcı bu analiz geçmişine ulaşabilir.

---

## ⚙️ Kullanılan Teknolojiler

### 🌐 Backend
- ASP.NET Core 8
- Entity Framework Core
- MassTransit + RabbitMQ (Event-driven mimari)
- PostgreSQL
- Clean Architecture
- Docker & Docker Compose

### 🧠 AI
- OpenAI GPT-4 API (chat/completion)
- Gerçek zamanlı kültürel ve coğrafi içerik üretimi

### 🌍 Frontend
- React + TypeScript
- Vite
- TailwindCSS
- React Leaflet (harita)
- Axios

---

###  Ekran Görüntüleri
