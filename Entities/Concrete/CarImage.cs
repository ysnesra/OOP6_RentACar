using Castle.Components.DictionaryAdapter;
using Core.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {      
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }       /* = "defaultImage.jpg";*/
        public DateTime ImageUploadDate { get; set; }    /* = DateTime.Now;*/
    }
}
//HATA!!!
//CarImage tablosunda bir primary key bulunmaması hatası.
//Burada "ImageId" isminde primarykey vermiştim
//***EntityFramework de default olarak primary key id veya class ismi +id şeklindedir.
//"ImageId" ismi gibi harici bir primary key ismi vermek istersek bunu [Key] data annotations ile veya Fluent Api üzerinden HasKey metodu ile belirtmeliyiz.