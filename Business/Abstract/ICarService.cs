using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        SuccessDataResult<List<Car>> GetAll(Expression<Func<Car,bool>> filter=null);
        SuccessDataResult<Car> GetCar(Expression<Func<Car, bool>> filter );
        SuccessDataResult<List<Car>> GetCarsBrandId(int brandId);
        SuccessDataResult<List<Car>> GetCarsColorId(int colorId);

        IResult Add(Car car);


    }
}
