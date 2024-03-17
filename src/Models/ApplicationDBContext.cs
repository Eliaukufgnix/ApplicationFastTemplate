using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("ApplicationDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // EF生成的sql表名不要被复数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Func> Func { get; set; }
    }
}