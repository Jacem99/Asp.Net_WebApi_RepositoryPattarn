using Microsoft.EntityFrameworkCore;
using RepositoryPattarnUOW.Core.Models;

namespace RepositoryPattarnUOW.EF
{
   public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
