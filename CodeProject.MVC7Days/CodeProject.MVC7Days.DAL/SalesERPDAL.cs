using System.Data.Entity;
using CodeProject.MVC7Days.Models;

namespace CodeProject.MVC7Days.DAL
{
    public class SalesERPDAL : DbContext
    {
        public SalesERPDAL()
            : base("SalesConnString")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}