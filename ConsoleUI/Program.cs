using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //GetAllMethod(carManager);
            //GetByBrandsMethod(carManager);
            //GetByColorsMethod(carManager);
            //GetCarDetailsMethod(carManager);
            //AddMethod(carManager);
            //UpdateMethod(carManager);
            //DeleteMethod(carManager);

            //ColorGetAll();
            //ColorAdd();
            //BrandGetAll();
            //BrandAdd();


        }

        private static void GetAllMethod(CarManager carManager)
        {
            var result = carManager.GetAll();
            if(result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void GetByBrandsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetByBrandId(2).Data)
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
            Console.WriteLine(carManager.GetByBrandId(2).Message);
        }

        private static void GetByColorsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetByColorId(3).Data)
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description} Rengi: {car.ColorId}");
            }
        }

        private static void GetCarDetailsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Arabanın ismi: {0} , Modeli: {1} , Rengi: {2}", car.CarName, car.BrandName, car.ColorName);
            }
        }

        private static void AddMethod(CarManager carManager)
        {
           var result= carManager.Add(new Car { BrandId = 6, ColorId = 4, CarName = "BMW", DailyPrice = 300000, Description = "BMW IX", ModelYear = 2023, UnitsInStock = 1 });

            if(result.Success==true)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void UpdateMethod(CarManager carManager)
        {
            carManager.Update(new Car { Id = 5002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void DeleteMethod(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 4002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }


        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var results= colorManager.GetAll();
            if(results.Success==true)
            {
                foreach (var color in results.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine(results.Message);
            }
            else
            {
                Console.WriteLine(results.Message);
            }
           

        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result=colorManager.Add(new Color { ColorName = "Gri" });
            if(result.Success==true)
            {
                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result=brandManager.GetAll();   
            if(result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.Add(new Brand { BrandName = "Wolkswagen" });
            if(result.Success == true)
            {
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
