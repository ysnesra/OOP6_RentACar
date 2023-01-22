using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IDataResult<List<Car>> GetAll()
        {
            //Hergün saat 22:00 ile 23:00 arası sistem kapalı olsun.Arabalar listelenemesin

            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);    //ICarDal'daki GetAll()'ı çağırır
        }
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId),Messages.CarDetail);
        }

        //filtreleme //Marka id si verilen aynı marka arabaları getirir 
        public IDataResult<List<Car>> GetByBrandId(int brandId)  
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), "Arabalar;Renk ve Marka isimleriyle birlikte listelendi");
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //if (car.CarName.Length <= 2 )
            //{
            //   return new ErrorResult(Messages.CarNameInvalid);
            //}

            //ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {  
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);     
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
  
    }

}