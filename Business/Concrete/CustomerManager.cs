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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;

        }
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccessResult();


        }

        public SuccessDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter), Message.Success);
        }

        public SuccessDataResult<Customer> GetCustomer(Expression<Func<Customer, bool>> filter)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(filter), Message.Success);
        }
    }
}
