using Lumini.FireKeeper.Domain.Entities.Authentication;
using Lumini.FireKeeper.Domain.Entities.Upload;
using Microsoft.EntityFrameworkCore;

namespace Lumini.FireKeeper.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        #region Authentication
        public DbSet<User> Users { get; set; }
        #endregion

        public DbSet<UserUpload> UserUploads { get; set; }
        public DbSet<AnonymousUpload> AnonymousUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
