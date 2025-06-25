# KurbanV1 - Hissedar Tablosu Yönetimi

KurbanV1, .NET 6 ve C# 10 ile geliştirilmiş, Windows Forms tabanlı bir hissedar yönetim uygulamasıdır. SQL server tabanlı çalışır ve kurban dağıtımını kolaylaştırır.

## Özellikler

- Hissedar ekleme, silme ve toplu silme (toplu silme ID sıfır)
- Hissedarları tablo halinde görüntüleme
- Ad-soyad ile hızlı arama
- Telefon numarası ve grup bilgisi ile kayıt
- SQL Server (KurbanDB) ile bağlantı
- Hissedarları 3 gruba atama(40-45KG, 45-50KG ve 50-55KG)

## Kurulum

1. **Gereksinimler:**
   - .NET 6.0.36 runtime [https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime](url)
   - SQL Server 22 (ör. SQLEXPRESS) [https://download.microsoft.com/download/5/1/4/5145fe04-4d30-4b85-b0d1-39533663a2f1/SQL2022-SSEI-Expr.exe](url)

2. **Kurulum:**
   Kuruluma ihtiyaç duymaz. Kurbanv1.exe dosyasını çalıştırın.

3. **Veritabanı:**
   - Uygulama, `.\SQLEXPRESS` sunucusuna ve `KurbanDB` veritabanına bağlanacak şekilde ayarlanmıştır.
  
4. **Troubleshoot:**
   - Hata almanız durumunda gereksinimleri doğru yüklediğinizden emin olun. Herhangi bir hata almadan program kapanıyorsa dosya dizesinde CMD çalıştırarak "dotnet kurbanv1.dll" kodunu çalıştırmayı deneyin.

## Kullanım

- Hissedar Tablosu butonuna basarak Hissedar eklemek için ad-soyad, telefon ve grup bilgilerini girin, ardından "Ekle" butonuna tıklayın.
- Bir hissedarı silmek için tablodan satır seçip "Sil" butonuna tıklayın.
- Tüm hissedarları silmek ve ID'leri sıfırlamak için Shift tuşuna basılı tutarak "Tam Sil" butonunu görünür yapın ve tıklayın.
- Hayvan ve Hissedar ekranlarında arama kutusuna ad-soyad girerek filtreleme yapabilirsiniz.
- Hayvan ekleme ekranında gerekli bilgileri doldurup hayvan ekleye bastığınızda sistem basit kontroller yapıp otomatik atama yapacaktır.
- Manuel düzenleme için Düzenle butonunu kullanabilirsiniz.

*Bu proje eğitim amaçlıdır.*

---

Uygulama, temel hata kontrolleri ve kullanıcı bilgilendirmeleri içerir, kullanımı sınırlandırmaması amacıyla sıkı kontrollerden kaçınılmıştır.
