using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService 
    {
        SuccessDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        SuccessDataResult<User> GetUser(Expression<Func<User, bool>> filter);
        IResult Add(User user);
    }
}
