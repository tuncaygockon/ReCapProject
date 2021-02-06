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
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car.CarId + "| Daily price: " + car.DailyPrice + "TL | Model Year: " + car.ModelYear);
            }

            foreach (var car in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(car.CarId + "| Daily price: " + car.DailyPrice + "TL | Model Year: " + car.ModelYear);
            }

            carManager.Add();

        }
    }
}
