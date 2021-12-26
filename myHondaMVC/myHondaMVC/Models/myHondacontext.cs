namespace myHondaMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class myHondacontext : DbContext
    {
        public myHondacontext()
            : base("name=myHondacontext")
        {
        }

        public virtual DbSet<anhminhhoa> anhminhhoas { get; set; }
        public virtual DbSet<chitietdathang> chitietdathangs { get; set; }
        public virtual DbSet<dathang> dathangs { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<lienhe> lienhes { get; set; }
        public virtual DbSet<loaixe> loaixes { get; set; }
        public virtual DbSet<nhacungcap> nhacungcaps { get; set; }
        public virtual DbSet<taikhoan> taikhoans { get; set; }
        public virtual DbSet<xemay> xemays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dathang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<dathang>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
