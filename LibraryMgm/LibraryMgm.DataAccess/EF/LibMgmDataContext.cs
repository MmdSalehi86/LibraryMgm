using System.Data.Entity;
using LibraryMgm.Model.Entities;

namespace School.DataAccess
{
    public class LibMgmDataContext : DbContext
    {
        public LibMgmDataContext() : base("Conn_LibMgmDb")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Translator> Translators { get; set; }
    }
}
