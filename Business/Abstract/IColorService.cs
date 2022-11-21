using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        void update(Color color);
        void delete(Color color);
        List<Color> GetAllBrand(Expression<Func<Color, bool>> filter = null);
        List<Color> GetBrandsById(int colorId);
    }
}
