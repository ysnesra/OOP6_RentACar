﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()     //constructor   //car listemizi oluşturdum
        {
            _cars = new List<Car> 
            {
                new Car{CarId=1,BrandId=1,ColorId=2,CarName="Audi",DailyPrice=100000,Description="Audi Q7 Model Comfort",ModelYear=2021,UnitsInStock=2 },
                new Car{CarId=2,BrandId=1,ColorId=3,CarName="Audi",DailyPrice=150000,Description="Audi Q5 Model Sportif",ModelYear=2022,UnitsInStock=5 },
                new Car{CarId=3,BrandId=3,ColorId=1,CarName="Volvo",DailyPrice=180000,Description="Volvo EX90 Model Elektrikli",ModelYear=2023,UnitsInStock=2 },
                new Car{CarId=3,BrandId=2,ColorId=1,CarName="BMW",DailyPrice=180000,Description="BMW iX Model Elektrikli",ModelYear=2023,UnitsInStock=1 },
            };   
        }


        public List<Car> GetAll()
        {
           return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car updatedCar=_cars.SingleOrDefault(x=>x.CarId==car.CarId);
            updatedCar.BrandId=car.BrandId; 
            updatedCar.ColorId=car.ColorId;
            updatedCar.CarName=car.CarName;
            updatedCar.DailyPrice=car.DailyPrice;
            updatedCar.Description=car.Description;
            updatedCar.ModelYear=car.ModelYear;
            updatedCar.UnitsInStock=car.UnitsInStock;
        }

        public void Delete(Car car)
        {
           Car deletedCar= _cars.SingleOrDefault(x=>x.CarId==car.CarId);
           _cars.Remove(deletedCar);
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(x=>x.BrandId==brandId).ToList();
        }

        public List<Car> GetByCarId(int carId)
        {
            return _cars.Where(x=>x.CarId==carId).ToList();
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _cars.Where(x => x.ColorId == colorId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
