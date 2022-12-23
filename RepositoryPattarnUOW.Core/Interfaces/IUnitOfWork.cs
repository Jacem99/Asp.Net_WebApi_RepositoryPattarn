using RepositoryPattarnUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.Core.Interfaces
{
        public interface IUnitOfWork : IDisposable
        {
            IBaseRepository<Teacher> Teachers { get; }
            IBaseRepository<Subject> Subjects { get; }

            int Complete();
    }
}
