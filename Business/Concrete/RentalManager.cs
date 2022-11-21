using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }
        public IResult Add(Rental car)
        {
            
            _rentalDal.Add(car);
            return new SuccessResult();


        }

        public SuccessDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter), Message.Success);
        }

        public SuccessDataResult<Rental> GetCar(Expression<Func<Rental, bool>> filter)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(filter), Message.Success);
        }

        public SuccessDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CarId == carId), Message.Success);
        }

        public SuccessDataResult<List<Rental>> GetRentalByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.CustomerId == CustomerId), Message.Success);
        }
    }
}
