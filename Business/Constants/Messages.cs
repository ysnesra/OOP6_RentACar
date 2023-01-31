using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarsListed = "Araçlar listelendi"; 
        public static string CarAdded = "Araba eklendi";
        public static string CarDetail = "Arabanın detay bilgilerini getirdi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarUpdated = "Araba bilgileri güncellendi"; 
        public static string CarUpdateConstraint = "Araba stokda 1 den fazla varsa güncellenebilir";
        public static string CarDeleted = "Araba silindi";
        
        public static string MaintenanceTime = "Sistem bakımda!";

        public static string ColorsListed = "Renler listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorUpdated = "Renk bilgileri güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string BrandsListed = "Markalar listelendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandUpdated = "Marka bilgileri güncellendi";
        public static string BrandDeleted = "Marka silindi";

        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerDetail = "Arabanın detay bilgilerini getirdi";
        public static string CustomerAdded = "Müşteri eklendi";   
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi";      
        public static string CustomerDeleted = "Müşteri sistemden silindi";

        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserDetail = "Kullanıcının detay bilgilerini getirdi";
        public static string UserWithCustomerListed = "Kullanıcılarla birlikte Müşteri bilgisinide getirdi";
        public static string UserEmailInvalid = "Mail adresi yanlış ";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi";
        public static string UserDeleted = "Kullanıcı sistemden silindi";

        public static string RentalsListed = "Kiralanan araçlar listelendi";
        public static string RentalDetail = "Kiralanan aracın detay bilgilerini getirdi";
        public static string RentalWithCustomerListed = "Kiralanan araçlarla birlikte Müşteri bilgisinide getirdi";
        public static string RentalNotDelivered = "Araç şuan kiralanamaz.Elimizde mevcut değil!"; 
        public static string RentalAdded = "Araba başarılı bir şekilde kiralandı";
        public static string RentalUpdated = "Kiralanan aracın bilgileri güncellendi";
        public static string RentalDeleted = "Kiralanan araç sistemden silindi";

        public static string CarImageListed = "Araç resimleri listelendi";
        public static string CarImageAdded = "Araba resimleri eklendi";       
        public static string CarImageLimitOverloading = "Araba resimleri en fazla 5 tane eklenebilir";
        public static string CarImageInvalid = "Araba resmi geçersiz";
        public static string CarImageUpdated = "Araba resimi güncellendi";       
        public static string CarImageDeleted = "Araba resmi silindi";

    }
}
