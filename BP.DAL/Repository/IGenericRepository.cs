using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BP.DAL.Repository
{
    public interface  IGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
