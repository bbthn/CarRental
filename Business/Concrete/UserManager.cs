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
    public class UserManager : IUserService 
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }
        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult();


        }

        public SuccessDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter), Message.Success);
        }

        public SuccessDataResult<User> GetUser(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter), Message.Success);
        }

    
    }
}
