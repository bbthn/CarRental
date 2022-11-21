using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
        where Tcontext : DbContext, new() //
    {
        public void Add(Tentity tentity)
        {
            using(Tcontext context = new Tcontext())
            {
                var AddedEntity = context.Entry(tentity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Tentity tentity)
        {
            using (Tcontext context = new Tcontext())
            {
                var DeletedEntity = context.Entry(tentity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);

            }
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                return filter == null
                    ? context.Set<Tentity>().ToList()
                    : context.Set<Tentity>().Where(filter).ToList();

            }
        }

        public void Update(Tentity tentity)
        {
            using (Tcontext context = new Tcontext())
            {
                var UpdatedEntity = context.Entry(tentity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
