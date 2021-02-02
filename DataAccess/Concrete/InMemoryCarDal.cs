using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { CarId = 1, BrandId = 1, ColorId = 4, DailyPrice = 200, Description = "KIA Picanto,Dizel", ModelYear = 2013 },
                new Car { CarId = 2, BrandId = 1, ColorId = 4, DailyPrice = 300, Description = "KIA Rio,Benzin", ModelYear = 2014 },
                new Car { CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 400, Description = "Honda Civic,Dizel", ModelYear = 2016 },
                new Car { CarId = 4, BrandId = 2, ColorId = 3, DailyPrice = 600, Description = "Honda CR-V,Benzin", ModelYear = 2018 },
                new Car { CarId = 5, BrandId = 3, ColorId = 2, DailyPrice = 500, Description = "Nissan Juke,Benzin", ModelYear = 2017 },
                new Car { CarId = 6, BrandId = 3, ColorId = 2, DailyPrice = 600, Description = "Nissan Qashqai,Benzin", ModelYear = 2018 },
                new Car { CarId = 7, BrandId = 4, ColorId = 1, DailyPrice = 700, Description = "Toyota Camry,Benzin", ModelYear = 2019 },
                new Car { CarId = 8, BrandId = 4, ColorId = 1, DailyPrice = 700, Description = "Toyota Yaris,Benzin", ModelYear = 2019 },
            };
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
    }
}
