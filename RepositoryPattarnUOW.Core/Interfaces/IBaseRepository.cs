using RepositoryPattarnUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.Core.Interfaces
{
  public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int Id);
        Task<T> GetByName(Expression<Func<T, bool>> exception);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> orderBy = null, string defaultOrderBy = OrderBy.Ascending);
        Task<IEnumerable<T>> ListOfInclude( Expression<Func<T,bool>> criteria, string[] includes=null);
        Task<IEnumerable<T>> ListOfOrderBy(Expression<Func<T, bool>> criteria =null, Expression<Func<T, object>> orderBy = null, string defaultOrderBy = OrderBy.Ascending);
        Task<IEnumerable<T>> ListOfInclude(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy = null, string[] includes = null, string defaultOrderBy = OrderBy.Ascending);
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int Id);
        int Count(Expression<Func<T, bool>> criteria =null);
    }
}
