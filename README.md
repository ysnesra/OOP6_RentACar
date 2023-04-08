# OOP6_RentACar
Araç kiralama takibinin yapıldığı n-tier Architecture mimari yaklaşımın kullanıldığı WebApi projesidir. 

Kullanılan Teknolojiler:

 * .NET Core 6.0
  
 * Asp.NET for Restful Api
  
 * MsSql
  
 * Entity FrameWork Core 6.0.13 
  
 * AutoFac
  
 * FluentValidation
 
Kullanılan Teknikler:

   * n-tier Architecture mimari yaklaşımı
   
   * JWT (Json Web Tokens)
   
   * AOP Yapısı

   * IoC

   * Microsoft Built In Dependency Resolver
   

Katmanlı mimariyle oluşturuldu : Entities, DataAccess, Business, Console, Core katmanları

Rent a Car Projesini Çok Katmanlı Kurumsal Mimari altyapısında oluşturdum 

*Core Katmanı oluşturup evrensel kodlarımızı yazdım: 

    1- "EfEntityRepositoryBase" clası oluşturup Generic Constraintlerini belirttim
    
    2- IEntity, IDto, IEntityRepository, EfEntityRepositoryBase dosyaları oluşturuldu.
    
    3- Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını gerçekleştirdim
    
-----------------------------------------

*Core katmanında Results yapılandırması yaptım.

  4- Core katmanına Utilities klasörü altına Results klasörü açtım
  
  5- Daha önce geliştirdiğiniz tüm Business sınıflarını bu yapıya göre refactor (kodu iyileştirme) yaptım
  
-------------------------------------------

* WebAPI
    WebAPI katmanını oluşturdum.
    Business katmanındaki tüm servislerin API karşılığını yazıp Postman'de test ettim.
    
-------------------------------------------
* 
    1.Autofac desteği ekledim.
    2.FluentValidation desteği ekledim.
    3.AOP (Aspect Oriented Programming) desteği ekledim.
      ValidationAspect 
      
-------------------------------------------
 *
1-Araba resimlerini tuttan CarImages tablosu oluşturdum. (Id,CarId,ImagePath,Date) Bir arabanın birden fazla resmi olabilir.

2-Api üzerinden arabaya resim ekleyecek sistemi yazdım.

3-Resimler projem içerisinde wwwroot\Uploads\Images klasöründe tutulmaktatır. Resimler yüklendiği isimle değil, kendi verdiğimiz GUID ile dosyalanmaktadır.

4-Resim silme, güncelleme yetenekleri ekledim.

5-Bir arabanın en fazla 5 resmi olabilir.Kuralını BusinessRules clasında oluşturuduğum Run metotu ile kontrol edip Add ve Upload işlemlerini ona göre gerçkleştirdim.

5-Resmin eklendiği tarih sistem tarafından atandı.(CarImageManager--> Add metotunda atama yapıldı)

6-Bir arabaya ait resimleri listeleme imkanı oluşturdum. (GetByCarId metotu ile)

7-Eğer bir arabaya ait resim yoksa, default bir resim gösterdim. Bu resim toplu arabaların olduğu bir resim. (Tek elemanlı liste) 
  
  -------------------------------------------
* JWT

1- UserTablosuna -> PasswordHash,PasswordSalt,Satatus kolonları eklendi
   OperationClaims ve UserOperationClaims tabloları eklendi
   Bu tabloların entity classlarını Core da oluştururuz (Genel her projede kullanılabilceği için)

2- appsetting.json dosyasına; Jwt nin configurationını ekledim. Tokenoptions isminde cofigurasyon oluşturdum.

3- Core katmanında ->Utilities ->Security klasörüne ->Encryption,Hashing ve Jwt klasörleri oluşturuldu.İçlerine Helper metotlar oluşturuldu. 

  * HashingHelper metotunda -> Hash oluşturma ve doğrulama operasyonları gerçekleşir.

  * SecurityKeyHelper -> appsetting de oluşturduğumuz securityKey değerini byte[] array formatına çevirmek için CreateSecurityKey metotu oluşturuldu
  * SigningCredentialsHelper -> webApinin hangi anahtarı hangi şifreleme algoritmasını kullanacağını söylediğimiz metot

  * AccessToken classı -> erişim anahtarı // Token ve Expiration değişkenlerini tanımlandı
  * ITokenHelper -> CreateToken metotu oluşturuldu (veritabanındaki user ve claimlere göre JWT Token üretecek)
  * JwtHelper -> Jwt'nin oluşturulduğu class 
  * TokenOptions -> Configuration ile appsettings.json da okuduğu değerleri atayacağımız değişkenleri tanımladığım class

 4- Extensions metot tanımladım.Claimler için
   
   * ClaimExtensions -> ClaimExtensions da tanımladığımız metotları JwtHelper.cs ında çağırırız
   * ClaimPrincipalExtensions -> Jwt den gelen claimlerini okumak için .Net deki "ClaimsPrincipal" clasına Claims ve ClaimRoles metotları eklendi
   * ServiceCollectionExtensions ->

5- Authorization (Yetkilnedirme) Aspectleri, Business katmanına yazıldı
   BusinessAspect klasörü -> Autofac klasörü -> SecuredOperation.cs clası oluşturuldu

   * SecuredOperation -> Aspect olarak verceğimiz yetkilendirme metotu
   * ServicTool -> WebApi de oluuşturduğumuz Injectionlar gibi ilişkileri oluşturmamızı sağlar.Aspecti Inject  edebilmek için oluşturdupumuz bir ExtensionsMetottur

6- IUserService'e -> GetByEmail,GetClaims metotları eklendi
   IAuthService, AuthManager, AuthController eklendi -> Kayıt olma - Login olma operasyonlarını gerçekleştirir

7-  Business -> DependencyResolvers -> Autofac -> AutofacBusinessModule.cs classı içine eklemeler yapıldı. JwtHelper ve AuthManger için dependency bağlantıları yazıldı

8- startup.cs'de sistemde authentication olarak hangi sistemin kullanılacağı belirtildi. JwtBearer Token kullanılır.

   startup.cs'de  "app.UseAuthentication();" middleware'i eklendi. Authorization() den önce olacak şekilde; çünkü önce kimlik doğrulanır sonra yetkilendirme verilir

9- Dependency Resolution'ı Autofac üzerinden yapıyoruz. .net in kendi IoC Injectionın devreye girmesi için;
   startup.cs'ye 
      "services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();" ve
      "serciceTool.Create(services);"  kodları eklendi.

   Ancak bu tanımladığım Injectionı bütün projelerde kullanılabilir hale getirmek için Core'a taşıdım
   *Core-> Utilities-> IoC-> ICoreModule.cs interfacei oluşturuldu -> Load() metodu tanımlandı(genel bağımlılıkları yükleyecek metotumuz)

   *Core-> DependencyResolvers-> CoreModule.cs clası oluşturuldu.IHttpContextAccessor ınjection kodu buraya yazıldı

   *Core-> Extensions-> ServiceCollectionExtensions.cs clası oluşturuldu.Bağımlılıkları yüklediğimiz "AddDependencyResolvers" metotu oluşturuldu.
   startup.cs'de bu AddDependencyResolvers metotu çağrılır ve parametre olrak CoreModule verilerek yüklenmesi sağlanır.

-------------------------------------------
* CACHE

-Micosoft'un kendi mekanizmasındaki InMemoryCache kullanıldı.
-Aspect kullanark Cache yapısı oluşturdum.
-GetAll(),GetByCarId()... gibi listeleme tek bir arab bilgilerini getirme gibi işlemlerde her seferinde veritabanına gitmemek için verileri Cache'den çektim.[CacheAspect] 
-Ancak Add(),Update(),Delete() işlemlerinde data bozulduğunda Cache deki verileri silmek için -> [CacheRemoveAspect] ni oluşturdum.
-CarManager.cs'da test ettim.

-------------------------------------------
* TRANSACTION

-Uygulamada tutarlığı korumak için transaction yöntemini uyguladım.
-ICarService.cs'e "AddTransactionalTest" metotu eklendi.
[TransactionScopeAspect] Aspecti; AddTransactionalTest metotunun üstüne eklendi

-------------------------------------------
* PERFORMANCE

-Uygulamada sistemin yavaşlama durumu(performans zafiyeti) varsa sistem bizi uyarsın istediğimden; Aspect oluşturdum.
-GetByCarId() metotunun üstüne; [PerforamanceAspect(5)] Aspecti eklendi. 

CACHE Yönetimi:
![Cache](https://user-images.githubusercontent.com/104023688/229637995-048c7aa6-9b90-44d7-8258-38026c1b8c49.JPG)

PERFORMANCE Yönetimi:
![Performance](https://user-images.githubusercontent.com/104023688/229638041-d75378e0-7064-4178-9399-b4618cfe0845.JPG)



