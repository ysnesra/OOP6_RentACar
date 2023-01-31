using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    //Directory=>System.IO'nın bir class'ı.
    //Bu Upload metodumun parametresi olan string root--> CarManager'dan gelmekte
    //*CarImageManagerda Add işlemei yapılırken buradaki Upload metotuna parametre olarak *PathConstants.ImagesPath* gönderir 
    //*PathConstants clası içerisinde resmin kaydedileceği dizin string olarak tanımlanmış
    //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur

    public class FileHelperManager : IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            if(file.Length > 0)  //dosya var mı//gönderilmiş mi gönderilmemiş mi
            {
                if (!Directory.Exists(root))    //dosyanın kayıt edileceği adres dizini yoksa if içine gir ve dosyayı oluştur
                {
                    Directory.CreateDirectory(root);  
                }
                //Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.(.jpg mi .png mi .txt mi)
                string extension = Path.GetExtension(file.FileName);

                //GuidHelper clasındaki CreateGuid metotunu çağırıp eşsiz bir guid stringi oluşturuyoruz
                string guid = GuidHelper.CreateGuid();

                // F45RG-YP956-H6KA.jpg kalıbında dosyanın adı//Dosyanın oluşturduğum adını ve uzantısını yan yana getirir.
                string filePath = guid + extension; 

                //Burada en başta FileStrem class'ının bir örneği oluşturulu., sonrasında File.Create(root + newPath)=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath)=>Oluşturulacak dosyanın yolu ve adı.
                using (FileStream fileStream = File.Create(root + filePath))
                {
                    //Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasının nereye kopyalacağını söyledik.
                    file.CopyTo(fileStream);

                    fileStream.Flush();  //arabellekten siler.
                    
                    //burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                    return filePath;
                }
            }
            return null;
        }

        //string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı
        public void Delete(string filePath)
        {    
                if (File.Exists(filePath)) //if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
                {
                    File.Delete(filePath);  //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
                }
            
        }

        //Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath)) //if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath); //Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }      
    }
}

//IFormFile projemize bir dosya yüklemek için kulanılan yöntemdir, HttpRequest ile gönderilen bir dosyayı temsil eder.
//FileStream, Stream ana soyut sınıfı kullanılarak genişletilmiş, belirtilen kaynak dosyalar üzerinde okuma/yazma/atlama gibi operasyonları yapmamıza yardımcı olan bir sınıftır
