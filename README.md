# KurbanV1 - Hissedar Tablosu Yönetimi

KurbanV1, .NET 6 ve C# 10 ile geliştirilmiş, Windows Forms tabanlı bir hissedar yönetim uygulamasıdır. Bu uygulama, bir SQL Server veritabanında hissedarların eklenmesi, silinmesi, listelenmesi ve aranmasını kolaylaştırır.

## Özellikler

- Hissedar ekleme, silme ve toplu silme (ID sıfırlama dahil)
- Hissedarları tablo halinde görüntüleme
- Ad-soyad ile hızlı arama
- Telefon numarası ve grup bilgisi ile kayıt
- SQL Server (KurbanDB) ile bağlantı
- Hissedarları 3 gruba atama(40-45KG, 45-50KG ve 50-55KG)

## Kurulum

1. **Gereksinimler:**
   - .NET 6 SDK
   - SQL Server (ör. SQLEXPRESS)
   - Visual Studio 2022 (veya üzeri)

2. **Veritabanı:**
   - `KurbanDB` adında bir veritabanı oluşturun.
   - Aşağıdaki tabloyu oluşturun:
     ```sql
     CREATE TABLE Hissedarlar (
         ID INT IDENTITY(1,1) PRIMARY KEY,
         AdSoyad NVARCHAR(100) NOT NULL,
         Telefon NVARCHAR(20),
         AgirlikAraligi NVARCHAR(50),
         AtandiMi BIT
     );
     ```

3. **Bağlantı Dizesi:**
   - Uygulama, `.\SQLEXPRESS` sunucusuna ve `KurbanDB` veritabanına bağlanacak şekilde ayarlanmıştır. Gerekirse `hissedarTablosu.cs` dosyasındaki bağlantı dizesini güncelleyin.

## Kullanım

- Hissedar eklemek için ad-soyad, telefon ve grup bilgilerini girin, ardından "Ekle" butonuna tıklayın.
- Bir hissedarı silmek için tablodan satır seçip "Sil" butonuna tıklayın.
- Tüm hissedarları silmek ve ID'leri sıfırlamak için Shift tuşuna basılı tutarak "Tam Sil" butonunu görünür yapın ve tıklayın.
- Hayvan ve Hissedar ekranlarında arama kutusuna ad-soyad girerek filtreleme yapabilirsiniz.
- Hayvan ekleme ekranında gerekli bilgileri doldurup hayvan ekleye bastığınızda sistem otomatik atama yapacaktır.
- Manuel düzenleme için Düzenle butonunu kullanabilirsiniz.

## Katkı ve Lisans

Bu proje eğitim amaçlıdır.

---

Uygulama, temel hata kontrolleri ve kullanıcı bilgilendirmeleri içerir. Geliştirme sırasında ek güvenlik ve doğrulama önlemleri eklenmesi önerilir.
