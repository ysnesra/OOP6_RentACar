using Business.Concrete;
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
            //AddMethod(carManager);
            //UpdateMethod(carManager);
            //DeleteMethod(carManager);

            //ColorGetAll();
            //ColorAdd();
            //BrandGetAll();
            //BrandAdd();

            GetCarDetailsMethod(carManager);

        }

        private static void GetAllMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void GetByBrandsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetByBrandId(2))
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void GetByColorsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetByColorId(3))
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description} Rengi: {car.ColorId}");
            }
        }

        private static void AddMethod(CarManager carManager)
        {
            carManager.Add(new Car { BrandId = 2, ColorId = 3, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Elektrikli", ModelYear = 2019, UnitsInStock = 4 });

            //Console.WriteLine(carManager.GetAll().Count);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void UpdateMethod(CarManager carManager)
        {
            carManager.Update(new Car { Id = 5002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void DeleteMethod(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 4002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "BMW" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void GetCarDetailsMethod(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Arabanın ismi: {0} , Modeli: {1} , Rengi: {2}", car.CarName, car.BrandName, car.ColorName);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Gri Parlak" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

    }
}
