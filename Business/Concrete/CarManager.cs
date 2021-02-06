using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add()
        {
            string brandName = null;
        brand: Console.WriteLine("Enter a Brand Name:");
            brandName = Console.ReadLine();
            if (brandName.Length < 2)
            {
                Console.WriteLine("Enter more than 2 characters.");
                goto brand;
            }
            Console.WriteLine("Enter your suggested daily price:");
            int dailyPrice = int.Parse(Console.ReadLine());
            if (dailyPrice < 1)
            {
                Console.WriteLine("Enter a price more than 0TL");
            }
            Console.WriteLine("Enter the model year:");
            int modelYear = int.Parse(Console.ReadLine());
            Console.WriteLine("You have successfully added your car.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car deleted successfully.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Car updated successfully.");
            }
            else
            {
                Console.WriteLine("Enter a price more than 0TL");
            }
        }
    }
}
