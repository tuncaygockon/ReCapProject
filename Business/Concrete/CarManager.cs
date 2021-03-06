﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            if (id < 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarIdInvalid);
            }
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), true, Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            if (id < 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.ColorIdInvalid);
            }
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), true, Messages.CarsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetCarDetails(int carId)
        {
            return new DataResult<List<ProductDetailDto>>(_carDal.GetProductDetails(p => p.CarId == carId), true, Messages.CarDetailsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new DataResult<List<ProductDetailDto>>(_carDal.GetProductDetails(filter), true, Messages.CarsListed);
        }

        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}

