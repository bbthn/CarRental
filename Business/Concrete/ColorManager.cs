using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;

        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public List<Color> GetAllBrand(Expression<Func<Color, bool>> filter = null)
        {
            return _colorDal.GetAll(filter);
        }

        public List<Color> GetBrandsById(int colorId)
        {
            return _colorDal.GetAll(p => p.ColorId == colorId);
        }

        public void update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
