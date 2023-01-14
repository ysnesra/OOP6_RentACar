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
    }
}
