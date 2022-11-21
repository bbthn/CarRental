using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void update(Brand brand);
        void delete(Brand brand);
        List<Brand> GetAllBrand(Expression<Func<Brand,bool>> filter =null);
        List<Brand> GetBrandsById(int brandId);



    }
}
