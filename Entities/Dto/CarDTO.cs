using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class CarDTO: IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public short UnitInStock { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
