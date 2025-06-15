# 🌍 Farlo Insight

**Farlo Insight**, yapay zeka destekli, konum tabanlı coğrafi ve kültürel analizler sunan modern bir mikroservis mimarili uygulamadır.  
Harita üzerinden seçilen herhangi bir konum için **OpenAI GPT-4** kullanarak anlamlı içgörüler üretir ve kullanıcıya sunar.

> 📌 Harita → Yapay Zeka → İçgörü zinciriyle gerçek zamanlı analiz deneyimi!

---



## 🧠 Nasıl Çalışır?

1. 📍 **Kullanıcı**, harita üzerinde bir koordinat seçer.  
2. 🌐 `GeoDataService`, bu konuma ait iklim, bitki örtüsü ve yükseklik verilerini üretir.  
3. 🤖 `AIService`, OpenAI GPT-4 kullanarak coğrafi analiz metni oluşturur.  
4. 🎭 `CultureService`, aynı verilerle kültürel bir özet metni üretir.  
5. 🧾 `InsightService`, bu analizleri ayrı ayrı veritabanına kaydeder.  
6. 🖥️ `Frontend`, tüm bu içerikleri kullanıcıya listeler ve görselleştirir.

---

## ⚙️ Kullanılan Teknolojiler

### 🔧 Backend
- **ASP.NET Core 8**
- **Entity Framework Core** (Code-First)
- **PostgreSQL**
- **RabbitMQ + MassTransit** (Event-Driven Architecture)
- **Docker & Docker Compose**
- **Clean Architecture**

### 🤖 Yapay Zeka
- **OpenAI GPT-4** API
- Gerçek zamanlı içerik üretimi (coğrafi & kültürel)

### 💻 Frontend
- **React + TypeScript**
- **Vite**
- **Tailwind CSS**
- **React Leaflet** (Harita işlemleri)
- **Axios**

---

## 🖼️ Uygulama Ekran Görüntüleri

### 🏠 Ana Sayfa
![Home](https://github.com/user-attachments/assets/9c1573f0-3b10-4cdb-b7e4-efd26ecc71b6)

### 🗺️ Harita Sayfası
![Map](https://github.com/user-attachments/assets/17323092-ef1a-4660-982c-3495a5366519)

### 🤖 AI Analizleri
![AI](https://github.com/user-attachments/assets/a1ce2bdd-c75e-4e00-89b7-6217188f0f5c)

### 🎭 Kültürel İçerikler
![Culture](https://github.com/user-attachments/assets/7e9a8b90-7b65-436f-ade8-6c675d6f0ddf)

### 📋 Listeleme Sayfası
![List](https://github.com/user-attachments/assets/a9fddcad-1d24-4600-bdcb-b07133d9d742)

---



