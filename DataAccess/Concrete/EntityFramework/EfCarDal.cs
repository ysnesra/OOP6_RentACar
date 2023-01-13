using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbRentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName, BrandName = b.BrandName,ColorName = cl.ColorName,
                                 UnitsInStock = c.UnitsInStock,DailyPrice = c.DailyPrice
                             };
                return result.ToList(); 
            }
        }
    }
}
