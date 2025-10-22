```
Solution
 └── src
      ├── Core
			
```

 ⚙️ **3. Core**
`Core` projenin **çekirdek (merkezi)** katmanıdır.
Burada **iş kuralları (business rules)**, **domain modelleri**, **interface (arayüz) tanımları** gibi mimarinin kalbi bulunur.
Yani “**uygulamanın ne yaptığ**ı” burada tanımlanır — “**nasıl yaptığı**” değil.
`Core` hiçbir şekilde dış katmanlara (örneğin veri tabanı, web API vs.) bağımlı değildir.

```
```
Solution
 └── src
      ├── Core
	  ├── Aplication
			
```
			
			


`Application` , **iş mantığının (business logic)** uygulandığı katmandır.

Burada genellikle şu yapılar yer alır:

- **Commands / Queries** → (CQRS yapısı kullanılıyorsa)
    
- **Interfaces** → servis sözleşmeleri (örneğin `IProductService`)
    
- **DTOs / ViewModels** → veri transfer nesneleri
    
- **Services / Handlers** → işlemleri yöneten sınıflar
    
- **Behaviors / Validators** → doğrulama ve işlem davranışları

Yani “**bir ürün nasıl eklenir, nasıl listelenir**” gibi kurallar Application katmanında tanımlanır,  
ancak “**veritabanına nasıl kaydedilir**” kısmı Core içinde **tanımlanmaz** — o işi Infrastructure veya Persistence katmanı yapar.


```
Solution
 └── src
      ├── Core
	  ├── Aplication
	  ├── Domain
			
```

Bu yapı, iş kuralları (business logic) ile iş kurallarının temel modellerini (entities, value objects) birbirinden ayırmak için kullanılır.
Şimdi sadece Domain katmanına odaklanalım 👇

🔹 Domain Katmanı Nedir?

Domain katmanı, uygulamanın iş kurallarının merkezidir (kalbidir).
Yani sistemin ne yaptığını tanımlar, nasıl yaptığını değil.

🔹 Görevi
Temel iş modellerini tanımlamak	Entity, Value Object, Enum gibi kavramlar burada bulunur.
Kuralları barındırmak	Örneğin: “Bir fatura iptal edilmeden ödeme yapılamaz.” gibi kurallar burada yer alır.
Bağımsız olmak	Domain hiçbir dış katmana (veritabanı, servis, API vs.) bağlı olmaz.
Sadece iş anlamına odaklanmak	Teknik detaylar (SQL, HTTP, dosya, API vs.) Domain’de bulunmaz.

🔹 İçeriğinde genelde bulunanlar

| Dosya / klasör    | Açıklama                                                      |
| ----------------- | ------------------------------------------------------------- |
| **Entities/**     | Temel varlıklar (ör. `User`, `Order`, `Product`)              |
| **ValueObjects/** | Değer nesneleri (ör. `Money`, `Address`, `Email`)             |
| **Enums/**        | Sabit durumlar (ör. `OrderStatus`, `UserRole`)                |
| **DomainEvents/** | Domain içinde meydana gelen olaylar (ör. `OrderCreatedEvent`) |
| **Exceptions/**   | Domain kuralları ihlallerini belirten özel istisnalar         |


```
Solution
 └── src
      ├── Core
      └── External
```

Clean Architecture yapısında **`External`** klasörü (veya bazen “Infrastructure”, “Adapters”, “Integration” olarak da adlandırılır), sistemin **dış dünya ile olan iletişimlerini** yöneten katmandır.

**External**, uygulamanın **harici bağımlılıklarını** ve **altyapı bağlantılarını** barındıran kısımdır.

### 🔹 External klasörünün amacı:

Uygulamanın çekirdek iş kuralları (Core) dışındaki, dış sistemlerle veya altyapılarla etkileşimde olan kodları ayırmaktır.

🔹 İçinde genellikle şunlar bulunur:

| Alt klasör / yapı                | Açıklama                                                                |
| -------------------------------- | ----------------------------------------------------------------------- |
| **Persistence / Infrastructure** | Veritabanı işlemleri (EF Core, Dapper, SQL vs.)                         |
| **API Clients**                  | Harici servislerle REST veya SOAP entegrasyonları                       |
| **Message Brokers**              | RabbitMQ, Kafka, Azure Service Bus gibi mesajlaşma altyapıları          |
| **File Storage**                 | Dosya sistemi veya bulut depolama bağlantıları (AWS S3, Azure Blob vs.) |
| **Email / SMS Services**         | Harici iletişim servisleri                                              |
| **Logging / Caching**            | Loglama veya cache altyapısı (Serilog, Redis vs.)                       |

```
Solution
 └── src
      ├── Core
      └── External
           ├── Infrastructure
```

**`Infrastructure` (altyapı)** klasörü genellikle **`External`** klasörünün içinde bulunur ve uygulamanın **altyapı bağımlılıklarını** (örneğin veritabanı, dosya sistemi, e-posta servisi gibi dış kaynaklar) yönetir.

🔹 Kısaca tanım:

**Infrastructure**, uygulamanın dış sistemlerle (veritabanı, dosya sistemi, servisler, mesaj kuyrukları vb.) olan **teknik altyapı katmanıdır**.  
Bu katman **Core’daki interface’leri** somut olarak (implementation) gerçekleştirir.

## 🔹 Görevi:

- **Veritabanı bağlantısı** kurmak (örneğin Entity Framework Context)
    
- **Repository** sınıflarını yazmak (Data Access)
    
- **Dosya veya e-posta işlemleri** gibi dış kaynakları kullanmak
    
- **Dependency Injection (DI)** yapılandırmalarını yapmak
    
- **Servis implementasyonlarını** sağlamak

```
Solution
 └── src
      ├── Core
      └── External
           ├── Infrastructure
           └── Persistence
```

Burada **`Persistence`**, Clean Architecture’da **veri erişim katmanıdır**.

**Persistence**, uygulamanın **veriyi kalıcı hale getirdiği** (örneğin veritabanına yazma, okuma, güncelleme, silme) işlemlerini yöneten katmandır.

## 🔹 Kısaca tanım:

**Persistence**, “verinin kalıcılığı” ile ilgilenir.  
Veritabanı bağlantısı, Entity Framework (EF Core) context’i, repository sınıfları ve veri modellerinin konfigürasyonları burada yer alır.

🔹 Persistence katmanının görevleri:

| Görev                             | Açıklama                                                                                                   |
| --------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| **Veritabanı bağlantısı**         | EF Core veya Dapper gibi araçlarla DB bağlantısını sağlar.                                                 |
| **DbContext yönetimi**            | EF Core `DbContext` sınıfı burada olur.                                                                    |
| **Entity konfigürasyonları**      | Tablo, kolon, ilişki ayarları (`EntityTypeConfiguration`) yapılır.                                         |
| **Repository implementasyonları** | Core katmanında tanımlı interface’lerin (örneğin `IUserRepository`) gerçek implementasyonları burada olur. |
| **Migration işlemleri**           | EF Core migration dosyaları genellikle burada tutulur.                                                     |

```
Solution
 └── src
      ├── Core
      └── External
           ├── Infrastructure
           ├── Persistence
           └── Presentation
```

`Presentation` nedir?

**Presentation**, uygulamanın **kullanıcıya veya dış dünyaya “sunulduğu” katmandır.**  
Başka bir deyişle: **Uygulamanın dış dünyadan (örneğin web, API, UI) gelen istekleri karşıladığı katmandır.**

Bu katman, API veya kullanıcı arayüzü (UI) üzerinden gelen talepleri alır,  
bunları **Application katmanına iletir** ve sonucu dış dünyaya döner.

🔹 Görevi:

| Görev                                     | Açıklama                                                                                        |
| ----------------------------------------- | ----------------------------------------------------------------------------------------------- |
| **HTTP API oluşturmak**                   | Web API controller’ları burada bulunur.                                                         |
| **Kullanıcı arayüzü (UI) sağlamak**       | Eğer proje MVC, Blazor, Angular vb. içeriyorsa bu katman onların başlangıç noktası olur.        |
| **Application katmanını çağırmak**        | İş mantığı Presentation’da değil, Application katmanında olur. Presentation sadece yönlendirir. |
| **API endpoint tanımlamak**               | `[HttpGet]`, `[HttpPost]`, `[Route]` gibi controller metodları burada bulunur.                  |
| **Validation ve Authorization başlatmak** | İstekleri doğrulamak, kullanıcı yetkisini kontrol etmek.                                        |
|       
|                                                                                                 |
```
🔹 Basit akış örneği:

[HTTP Request] → Presentation (Controller)
                     ↓
               Application (Service)
                     ↓
              Persistence (Database)
                     ↓
         Infrastructure (Destek servisler)
                     ↓
[HTTP Response] ← Presentation
```

```
Solution
 └── src
      ├── Core
      ├── External
      │   ├── Infrastructure
      │   ├── Persistence
      │   └── Presentation
 └── test
 ```

Uygulamanın **otomatik testlerini** (unit test, integration test vb.) tutmaktır.

## 🔹 Kısaca tanım:

> **`test` klasörü**, proje kodunun doğruluğunu, hatasız çalıştığını ve gelecekteki değişikliklerden etkilenmediğini test etmek için yazılan **test projelerini** barındırır.


| Test türü                                | Açıklama                                                                                 |
| ---------------------------------------- | ---------------------------------------------------------------------------------------- |
| **Unit Test (Birim Testi)**              | Kodun en küçük parçalarını (ör. bir servis veya metot) tek başına test eder.             |
| **Integration Test (Entegrasyon Testi)** | Farklı katmanların (örneğin API ↔ DB ↔ Service) birlikte doğru çalıştığını kontrol eder. |
| **End-to-End Test (Uçtan Uca Test)**     | Gerçek kullanıcı senaryolarını (örneğin API isteği → veritabanı → cevap) test eder.      |
