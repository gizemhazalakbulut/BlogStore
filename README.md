🧩 Blog Store — Katmanlı Mimari & Akıllı Yorum Filtresi

Modern .NET ekosistemiyle geliştirilmiş, ölçeklenebilir ve bakımı kolay bir blog uygulaması.
UI tarafı hızlı tepki verir, veri erişimi net sınırlar içinde tutulur ve yorumlar toksik içerik açısından otomatik denetlenir.

🏗️ Mimari Genel Bakış

Uygulama, katmanlar arası bağımlılığı azaltmak ve değişiklikleri izole etmek için katmanlı mimari ile kurgulandı:

Presentation  →  Business  →  DataAccess  →  Entity
(UI + MVC)      (iş kuralları)  (EF Core)    (POCO)

- Gevşek bağlılık: Her katman kendi sorumluluğunda çalışır.

- Temiz akış: UI’dan veritabanına doğrudan erişim yoktur; tüm istekler Business katmanından geçer.

- Okunabilir & güvenli URL’ler: ID yerine slug kullanılır (örn. /articles/guvenli-kodlama-prensipleri).

 🧱 Katmanların Sorumlulukları
 
1) Presentation (Sunum) 🖥️

- MVC Controller’lar, View’lar, ViewModel’ler
- Doğrulama, yönlendirme, kullanıcı etkileşimi

2) Entity (Varlık) 📦

- POCO modeller: AppUser, Article, Category, Tag
- Sadece veri taşıma; iş mantığı yok

3) DataAccess (Veri Erişimi) 💾

- Entity Framework Core ile CRUD ve özel sorgular
- Test edilebilir, düzenli sorgu yapısı (repository-benzeri yaklaşım)

4) Business (İş Mantığı) ⚙️

- Kurallar, doğrulamalar, akış kontrolü
- Servis/Manager sınıfları ile tüm iş süreçleri

✨ Öne Çıkan Özellikler

Slug tabanlı URL: Daha okunabilir ve güvenli yönlendirme

AJAX yorumları: Sayfa yenilemeden yorum ekleme/çekme

Identity ile güvenli oturum: Kayıt, giriş, parola sıfırlama, yetkilendirme

Yorum görünürlüğü: Oturum yoksa yorum alanı yerine giriş çağrısı

Yönetim Paneli: Kategori-makale dağılım grafiği, “son eklenenler”, içerik yönetimi

Temiz bağımlılık kaydı: Extension pattern ile sade Program.cs

🤖 Akıllı Yorum Filtresi

Toksik/zararlı yorumları engellemek için bir analiz hattı uygulanır:

TR → EN çeviri (örn. Helsinki-NLP/opus-mt-tr-en)

Toksisite analizi (ToxicBERT)

Politika: Eşik üzerindekiler reddedilir veya moderasyona düşer

Not: Bu hat, .NET içinden bir servis olarak tetiklenebilir. Model tarafı ayrı bir Python servisi olarak koşturulup HTTP üzerinden entegre edilebilir; böylece yatayda ölçeklenir.

🖥️ Sayfalar
👩‍💼 Admin Paneli

Dashboard: Kategori-makale dağılım grafiği, son 4 makale, son 5 yorum

Makalelerim: Yazara ait içerikler (kart görünümü)

Yeni Makale: Başlık, görsel, kategori, içerik ile hızlı ekleme

Profilim: Bilgi güncelleme (gerekirse güncelleme sonrası oturum kapatma)

🌐 UI (Kullanıcı Arayüzü)

Ana Sayfa: Tüm makaleler, detayda yazar ve yorumlar

Kategoriler: Kategori bazlı listeleme

Yazarlar: Yazar profilleri ve yazıları

Giriş: Admin paneli ve yorum için kimlik doğrulama

🧰 Kullanılan Teknolojiler

.NET (ASP.NET Core MVC)

Entity Framework Core (Code-First, Migrations)

ASP.NET Identity

Bootstrap 5, jQuery/AJAX

(Opsiyonel) Chart.js — yönetim grafikleri

(Opsiyonel) Python + Transformers — ToxicBERT & Helsinki çeviri
