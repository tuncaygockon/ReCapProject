using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
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

            GetAll(carManager);
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.productDetailDtos())
            {
                Console.WriteLine("Model: {0}  /  Brand: {2}  /  Color: {1}  /  Daily Price: {3}TL", car.Description, car.ColorName, car.BrandName, car.DailyPrice);
            }
        }
    }
}
