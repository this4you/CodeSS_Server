using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeSS_Server.CoreEF.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);

        void Save();

    }
}
