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
            UserManager userManager = new UserManager(new EfUserDal());

            Car carToAdd = new Car { CarId = 12, BrandId = 1, CarName = "KIA Bingus", ColorId = 1, DailyPrice = 400, ModelYear = 2016, Description="Benzin"};
            Car carToUpdate = new Car { DailyPrice = 420 };
            Rental rentToAdd = new Rental { Id = 5, CarId = 2, CustomerId = 3, RentDate = new DateTime(13 / 02 / 2021), ReturnDate = new DateTime() };
            Rental rentToUpdate = new Rental { ReturnDate = new DateTime(16 / 02 / 2021) };

            carManager.Add(carToAdd);
            
        }
    }
}
