using Business.Concrete;
using Core.Entities.Concrete;
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

            //CustomerGetAll();
            //CustomerGetById(); //tek müşteri geliyor.MüşteriDETAY
            //CustomerAdd();

            //UserGetAll();
            //UserAdd();
            //GetUserDetailsWithCustomer();
            //GetUserDetailsByEmailMethod();

            //RentalAdd();
            GetRentalDetails();

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
        //Car-Brand-Color Join
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
            carManager.Update(new Car { CarId = 5002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Araba: {car.CarName} Modeli: {car.Description}");
            }
        }
        private static void DeleteMethod(CarManager carManager)
        {
            carManager.Delete(new Car { CarId = 4002, BrandId = 2, ColorId = 4, CarName = "Skoda", DailyPrice = 120000, Description = "Skoda Dizel Arazi", ModelYear = 2022, UnitsInStock = 6 });

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

        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("Müşteri ismi: {0} / Müşterinin şirketi: {1}", customer.CustomerFirstName, customer.CompanyName);
            }
        }
        private static void CustomerGetById()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetById(1).Data;
            Console.WriteLine("Müşteri ismi: {0} / Müşterinin şirketi: {1}", result.CustomerFirstName, result.CompanyName);
        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 3, CustomerFirstName = "Melek", CustomerLastName = "Pamuk", CompanyName = "Mng" });
            if (result.Success == true)
            {
                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine($"Müşteri: {customer.CustomerFirstName} Şirketi: {customer.CompanyName}");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("Kullanıcının ismi: {0} /  Maili: {1}", user.FirstName, user.Email);
            }
        }
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName = "İsmail", LastName = "Tıfıl", Email = "ismail@gmail.com",/* Password = "9999999"*/ });
            if (result.Success == true)
            {
                foreach (var user in userManager.GetAll().Data)
                {
                    Console.WriteLine($"Kullanıcı: {user.FirstName} Maili: {user.Email}");
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }  
        //User-Customer Join
        private static void GetUserDetailsWithCustomer()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetUserDetails().Data)
            {
                Console.WriteLine("Kullanıcının ismi: {0} /  Maili: {1} / Şirketi: {2}", user.UserFirstName, user.Email, user.CompanyName);
            }
        }
        //User-Customer Join By Email
        private static void GetUserDetailsByEmailMethod()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserDetailsByEmail("ysnesra@gmail.com").Data;
            Console.WriteLine("Kullanıcının ismi: {0} /  Maili: {1} / Şirketi: {2}", result.UserFirstName, result.Email, result.CompanyName);
        }

        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = new DateTime(2023, 01, 17) });
            Console.WriteLine(result.Message);

            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Araç Id bilgis: {0} /  Kiralanma tarihi: {1}", rental.CarId, rental.RentDate);
            }
        }
        //Rental-Car-Customer Join
        private static void GetRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine($"{rental.CarName} arabası; {rental.CustomerFirstName} {rental.CustomerLastName} müşterimize {rental.RentDate} - {rental.ReturnDate} tarihleri arasında kiraya verilmiştir.");
            }
        }

    }
}
