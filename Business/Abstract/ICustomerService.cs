using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        SuccessDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null);
        SuccessDataResult<Customer> GetCustomer(Expression<Func<Customer, bool>> filter);
        IResult Add(Customer customer);

    }
}
