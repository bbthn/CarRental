using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttinConsern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;
        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);

            
                if (car.DailyPrice > 0)
                {
                    _cardal.Add(car);
                    return new SuccessResult();

                }

            
            
            
            return new ErrorResult(Message.Failed);
            
        }

        public SuccessDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(filter),Message.Success);
        }

        public SuccessDataResult<Car> GetCar(Expression<Func<Car, bool>> filter)
        {
            return new SuccessDataResult<Car>(_cardal.Get(filter),Message.Success);
        }

        public SuccessDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.BrandId == brandId),Message.Success);
        }

        public SuccessDataResult<List<Car>> GetCarsColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.ColorId == colorId), Message.Success);
        }
    }
}
