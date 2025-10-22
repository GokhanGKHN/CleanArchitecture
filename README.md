```
Solution
	src → Uygulamanın ana kodları
		Core →
			
```

 ⚙️ **3. Core**
`Core` projenin **çekirdek (merkezi)** katmanıdır.
Burada **iş kuralları (business rules)**, **domain modelleri**, **interface (arayüz) tanımları** gibi mimarinin kalbi bulunur.
Yani “**uygulamanın ne yaptığ**ı” burada tanımlanır — “**nasıl yaptığı**” değil.
`Core` hiçbir şekilde dış katmanlara (örneğin veri tabanı, web API vs.) bağımlı değildir.

```
Solution
	src Uygulamanın ana kodları
		Core 
			Application
			
			
```

`Application` klasörü, **iş mantığının (business logic)** uygulandığı katmandır.

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
	src
		Core
		External
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
	src
		Core
		External
			Infrastructure
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
