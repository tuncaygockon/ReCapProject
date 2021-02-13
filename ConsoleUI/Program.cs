using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Car carToAdd = new Car { CarId = 11, BrandId = 1, Description = "KIA Buster", ColorId = 1, DailyPrice = 400, ModelYear = 2016};
            Car carToUpdate = new Car { DailyPrice = 650 };
            Rental rentToAdd = new Rental { Id = 5, CarId = 2, CustomerId = 3, RentDate = new DateTime(13 / 02 / 2021), ReturnDate = new DateTime() };
            Rental rentToUpdate = new Rental { ReturnDate = new DateTime(16 / 02 / 2021) };
            
            _ = new CarManager(new EfCarDal());
            carManager.Add(carToAdd);
            Console.WriteLine("------------");

            Console.WriteLine("------------");
            _ = new RentalManager(new EfRentalDal());
            rentalManager.Add(rentToAdd);
            Console.WriteLine("------------");
        }
    }
}
