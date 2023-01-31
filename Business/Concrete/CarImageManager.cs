using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountLimit(carImage.CarId));
            if(result != null)   //Run metotu kurala uyuyorsa null dönderir
            {
                return result;
            }
            //Resmi eklerken dosyayıda belirtilen dosya yoluna yükleyecek(upload edecek)  //veritabanında ImagePath de tutar
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.ImageUploadDate = DateTime.Now;  //veritabaınında ImageUploadDate'e bugünün tarihini ata
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);  //wwwroot\\Uploads\\Images\\3hhgf-hs964-şl4jg.jpg
            _carImageDal.Delete(carImage);   
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath= _fileHelper.Update(file, PathConstants.ImagesPath+ carImage.ImagePath , PathConstants.ImagesPath);
            carImage.ImageUploadDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfImageOfCar(carId));
            if(result!=null)   //Run metotu kurala uyuyorsa null dönderir if den çıkar
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        //Bir arabanın en fazla 5 resmi olabilir Kuralı
        private IResult CheckIfImageCountLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if(result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        //Bir Arabaya ait hiç resim yoksa default resmi göster Kuralı

        //*Arabanın resimi var mı kontrolünü yapan metot
        private IResult CheckIfImageOfCar(int carId)
        {
            var result=_carImageDal.GetAll(c=>c.CarId == carId).Count;  //CarImage de carId yoksa Image yok demektir
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        //*Default Resimi getiren metot (Tek elemanlı liste) 
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage { CarId = carId , ImageUploadDate=DateTime.Now, ImagePath="DefaultImage.jpg"});
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
