using RepositoryPattarnUOW.Core.Interfaces;
using RepositoryPattarnUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.EF.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IBaseRepository<Teacher> Teachers { get; private set; }
        public IBaseRepository<Subject> Subjects { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            Teachers = new BaseRepository<Teacher>(_dbContext);
            Subjects = new BaseRepository<Subject>(_dbContext);
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
