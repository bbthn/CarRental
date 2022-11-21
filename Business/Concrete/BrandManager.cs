using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;

        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            Console.WriteLine("Markanaın karakter sayisi 2den fazla olmalidir");
        }

        public void delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAllBrand(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.GetAll(filter);
        }

        public List<Brand> GetBrandsById(int brandId)
        {
            return _brandDal.GetAll(p=>p.BrandId==brandId);
        }

        public void update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
