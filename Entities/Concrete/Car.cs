using Core.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {    
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }      
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
