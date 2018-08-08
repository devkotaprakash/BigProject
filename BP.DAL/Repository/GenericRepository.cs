using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.DAL.Repository
{
    public abstract class GenericRepository<C,T> :IGenericRepository<T> where T:class where C:DbContext,new()
    {
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

     

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Set<T>().Update(entity);
            //_entities.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
