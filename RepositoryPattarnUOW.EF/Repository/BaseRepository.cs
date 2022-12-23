using Microsoft.EntityFrameworkCore;
using RepositoryPattarnUOW.Core.Consts;
using RepositoryPattarnUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<T> GetById(int Id) => await _dbContext.Set<T>().FindAsync(Id);

        public async Task<T> GetByName(Expression<Func<T, bool>> exception) => await _dbContext.Set<T>().SingleOrDefaultAsync(exception);

        public async Task<IEnumerable<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>> orderBy = null, string defaultOrderBy = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (orderBy != null)
            {
                if (defaultOrderBy == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {

                    query = query.OrderByDescending(orderBy);
                }
            }

            return await query.AsSplitQuery().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> ListOfInclude(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(criteria);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.AsSplitQuery().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> ListOfInclude(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy =null, string[] includes = null , string defaultOrderBy = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(criteria);
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if(orderBy != null)
            {
                if(defaultOrderBy == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                query = query.OrderByDescending(orderBy);
            }

            return await query.AsSplitQuery().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> ListOfOrderBy(Expression<Func<T, bool>> criteria = null, Expression<Func<T, object>> orderBy = null, string defaultOrderBy = "ASC")
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (criteria != null)
                query = query.Where(criteria);

            if (orderBy != null)
            {
                if (defaultOrderBy == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {

                query = query.OrderByDescending(orderBy);
                }
            }

            return await query.AsSplitQuery().AsNoTracking().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }
        public T Update(T entity)
        {
             _dbContext.Set<T>().Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
        }
        public void Delete(int Id)
        {
            var entity =_dbContext.Set<T>().Find(Id);
            _dbContext.Set<T>().Remove(entity);
        }
        public int Count(Expression<Func<T, bool>> criteria = null)
        {
           IQueryable<T> query = _dbContext.Set<T>();
            if(criteria != null)
            {
                return query.Count(criteria);
            }
            return query.Count();
        }

    }
}
