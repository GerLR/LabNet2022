using System.Data.Entity;
using TP4.EF.Entities;
using TP4.EF.Logic;

namespace TP4.EF.Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
        }

        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
        }
    }
}
