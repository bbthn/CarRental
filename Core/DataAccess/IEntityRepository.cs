using Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        void Add(T tentity);
        void Delete(T tentity);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Update(T tentity);

       
    }
}
