# 🧩 Blog Store — Katmanlı Mimari & Akıllı Yorum Filtresi

Modern .NET ekosistemiyle geliştirilmiş, **ölçeklenebilir** ve **bakımı kolay** bir blog uygulaması.  
UI hızlı, veri erişimi katmanlı, yorumlar **toksik içerik** açısından otomatik denetlenir.

---

## 🏗️ Mimari Genel Bakış

Uygulama, katmanlar arası bağımlılığı azaltmak ve değişiklikleri izole etmek için **katmanlı mimari** ile kurgulandı:


- **Gevşek bağlılık:** Her katman kendi sorumluluğunda çalışır.  
- **Temiz akış:** UI’dan veritabanına direkt erişim yok; tüm istekler **Business** üzerinden ilerler.  
- **Okunabilir & güvenli URL:** `ID` yerine **slug** (örn. `/articles/guvenli-kodlama-prensipleri`).  

---

## 🧱 Katmanların Sorumlulukları

### 1) Presentation (Sunum) 🖥️
- MVC Controller’lar, View’lar, ViewModel’ler  
- Doğrulama, yönlendirme, kullanıcı etkileşimi

### 2) Entity (Varlık) 📦
- POCO modeller: `AppUser`, `Article`, `Category`, `Tag`  
- Sadece veri taşıma; **iş mantığı içermez**

### 3) DataAccess (Veri Erişimi) 💾
- **EF Core** ile CRUD ve özel sorgular  
- Test edilebilir, düzenli sorgu yapısı (repository-benzeri yaklaşım)

### 4) Business (İş Mantığı) ⚙️
- Kurallar, doğrulamalar, akış kontrolü  
- Servis/Manager sınıfları ile tüm iş süreçleri

---

## ✨ Öne Çıkan Özellikler

- **Slug tabanlı URL** ile daha okunabilir/güvenli yönlendirme  
- **AJAX yorumları:** Sayfa yenilemeden gönder/al  
- **ASP.NET Identity:** Kayıt, giriş, parola sıfırlama, yetkilendirme  
- **Yorum görünürlüğü:** Oturum yoksa yorum alanı yerine giriş çağrısı  
- **Yönetim Paneli:** Kategori–makale dağılım grafiği, “son eklenenler” ve içerik yönetimi  
- **Temiz bağımlılık kaydı:** Extension pattern ile sade `Program.cs`  

---

## 📚 Varlıklar ve İlişkiler

| Varlık     | Açıklama                                 |
|------------|-------------------------------------------|
| `AppUser`  | Kullanıcı hesap bilgileri                 |
| `Article`  | Başlık, içerik, görsel, slug vb.          |
| `Category` | Makalenin ait olduğu kategori             |
| `Tag`      | Makalelere iliştirilen etiketler          |

**İlişkiler:** Her `Article`, bir **`AppUser`** tarafından yazılır. Kategori/etiketlerle N–N ilişkiler kurgulanabilir.

---

## 🤖 Akıllı Yorum Filtresi

Toksik/zararlı yorumları engellemek için bir **analiz hattı** çalışır:

1. **TR → EN çeviri** (örn. *Helsinki-NLP/opus-mt-tr-en*)  
2. **Toksisite analizi** (*ToxicBERT*)  
3. **Politika:** Eşik üzerindekiler reddedilir veya moderasyona düşer

> Mimari öneri: Dil modeli/bert bileşenini bağımsız **Python servisi** olarak koşturup .NET’ten HTTP ile çağırarak ölçeklenebilirliği artır.

---

## 🖥️ Sayfalar

### 👩‍💼 Admin Paneli
- **Dashboard:** Kategori–makale dağılım grafiği, son 4 makale, son 5 yorum  
- **Makalelerim:** Yazara ait içerikler (kart görünümü)  
- **Yeni Makale:** Başlık, görsel, kategori, içerik ile hızlı ekleme  
- **Profilim:** Bilgi güncelleme (gerekirse güncelleme sonrası oturum kapatma)

### 🌐 UI (Kullanıcı Arayüzü)
- **Ana Sayfa:** Tüm makaleler; detayda yazar ve yorumlar  
- **Kategoriler:** Kategori bazlı listeleme  
- **Yazarlar:** Yazar profilleri ve yazıları  
- **Giriş:** Admin paneli ve yorum için kimlik doğrulama

---

## 🧰 Kullanılan Teknolojiler

- **.NET (ASP.NET Core MVC)**  
- **Entity Framework Core** (Code-First, Migrations)  
- **ASP.NET Identity**  
- **Bootstrap 5**, **jQuery/AJAX**  
- *(Opsiyonel)* **Chart.js** — yönetim grafikleri  
- *(Opsiyonel)* **Python + Transformers** — ToxicBERT & Helsinki çeviri

## 🧰 Görseller

<img width="1863" height="915" alt="anasayfa" src="https://github.com/user-attachments/assets/6e343d81-cba6-4f93-8218-0e83bfea3833" />



