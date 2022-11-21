using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        SuccessDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null);
        SuccessDataResult<Rental> GetCar(Expression<Func<Rental, bool>> filter);
        SuccessDataResult<List<Rental>> GetRentalByCarId(int carId);
        SuccessDataResult<List<Rental>> GetRentalByCustomerId(int CustomerId);

        IResult Add(Rental car);

    }
}
