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


           GetByBrandsMethod(carManager);


            //GetByColorsMethod(carManager);


            //AddMethod(carManager);

            //UpdateMethod(carManager);

            //DeleteMethod(carManager);

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

            carManager.Add(new Car { BrandId = 2, ColorId = 3, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Elektrikli", ModelYear = 2019, UnitInStock = 4 });

            //Console.WriteLine(carManager.GetAll().Count);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void UpdateMethod(CarManager carManager)
        {
            carManager.Update(new Car { Id = 5002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitInStock = 6 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }

        private static void DeleteMethod(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 4002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitInStock = 6 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }


    }
}
