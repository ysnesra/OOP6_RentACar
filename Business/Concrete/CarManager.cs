using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Dependency Injection
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();    //ICarDal'daki GetAll()'ı çağırır
        }

        public List<Car> GetByBrandId(int brandid)    //filtreleme //Marka id si verilen aynı marka arabaları getirir 
        {
            return _carDal.GetAll(x => x.BrandId == brandid);
        }

        public List<Car> GetByColorId(int colorid)
        {
            return _carDal.GetAll(x => x.ColorId == colorid);
        }


        public void Add(Car car)
        {
            if (car.CarName.Length <= 2 && car.DailyPrice < 0)
            {
                throw new Exception("Araba ismi 2 karakterden az olamaz!");
            }
            else
            {
                _carDal.Add(car);
            }

        }

        public void Update(Car car)
        {
            if (car.UnitsInStock > 1)
            {
                _carDal.Update(car);
            }
            else
            {
                throw new Exception("Araba stokda 1 den fazla varsa güncellenebilir");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }

}