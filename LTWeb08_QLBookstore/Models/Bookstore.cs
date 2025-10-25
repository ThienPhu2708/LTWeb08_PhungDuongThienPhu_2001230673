namespace LTWeb08_QLBookstore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bookstore : DbContext
    {
        public Bookstore()
            : base("name=Bookstore")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANG { get; set; }
        public virtual DbSet<CHUDE> CHUDE { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANG { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBAN { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MADONHANG)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDONHANG>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CHUDE>()
                .Property(e => e.MACD)
                .IsUnicode(false);

            modelBuilder.Entity<CHUDE>()
                .HasMany(e => e.SACH)
                .WithOptional(e => e.CHUDE)
                .HasForeignKey(e => e.MACHUDE);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.MADON)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONHANG)
                .WithRequired(e => e.DONDATHANG)
                .HasForeignKey(e => e.MADONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.MANXB)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MASACH)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.GIABAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SACH>()
                .Property(e => e.ANHBIA)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MACHUDE)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MANXB)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETDONHANG)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.TACGIA)
                .WithMany(e => e.SACH)
                .Map(m => m.ToTable("VIETSACH").MapLeftKey("MASACH").MapRightKey("MATG"));

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.MATG)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);
        }
    }
}
