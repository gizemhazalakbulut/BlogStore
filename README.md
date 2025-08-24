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

## Görseller

<img width="1863" height="915" alt="anasayfa" src="https://github.com/user-attachments/assets/6e343d81-cba6-4f93-8218-0e83bfea3833" />

<img width="1796" height="836" alt="kategoriler" src="https://github.com/user-attachments/assets/fa1f73a4-af35-4aba-aa85-6078b7515be3" />

<img width="1503" height="903" alt="yazarlar" src="https://github.com/user-attachments/assets/4bb3edb4-b253-4064-863f-53f3ecd88b33" />

<img width="1858" height="914" alt="makale detay" src="https://github.com/user-attachments/assets/a6c17d3e-78a8-41e7-9d53-cbe805452fab" />

<img width="1496" height="911" alt="detay" src="https://github.com/user-attachments/assets/38526be9-ecb4-4553-802e-1bf24cfca17f" />

<img width="1551" height="924" alt="yorum yap yok" src="https://github.com/user-attachments/assets/084e1a31-b4b5-40a7-9254-867f321ed5de" />

<img width="1202" height="544" alt="başarılı yorum" src="https://github.com/user-attachments/assets/1e8c608d-3d86-4c3b-ab4b-044aad4aad75" />

<img width="1881" height="907" alt="toksik yorum" src="https://github.com/user-attachments/assets/1fdda72b-204e-4ea2-a4ad-863533bbaa03" />

<img width="1113" height="867" alt="giriş yap" src="https://github.com/user-attachments/assets/9c6b6a82-c065-4549-8018-25e40e8cb2af" />

<img width="595" height="615" alt="kayıt ol" src="https://github.com/user-attachments/assets/986ae7fe-f584-4fe7-a3a3-cef536b373a1" />

<img width="1887" height="910" alt="dashboard" src="https://github.com/user-attachments/assets/7fd20ded-4306-4a13-a578-0cf6ad30ba53" />

<img width="1889" height="916" alt="makale listem" src="https://github.com/user-attachments/assets/b6dadee2-ddeb-4491-b361-ed5871a456d8" />

<img width="1891" height="868" alt="yeni makale" src="https://github.com/user-attachments/assets/1a569d7e-32ac-462f-bb8a-164d307ced02" />

<img width="1887" height="860" alt="profil güncelleme" src="https://github.com/user-attachments/assets/6cc13873-3efd-44bc-97fc-dc8d9766aace" />
