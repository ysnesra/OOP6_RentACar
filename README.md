# OOP6_RentACar

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
  
