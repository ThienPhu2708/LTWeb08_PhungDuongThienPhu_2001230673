namespace QL_Employee.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.DEPT_ID)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.IMAGES_EMP)
                .IsUnicode(false);
        }
    }
}
