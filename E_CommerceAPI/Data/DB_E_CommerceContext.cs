using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_CommerceAPI
{
    public partial class DB_E_CommerceContext : DbContext
    {
        public DB_E_CommerceContext()
        {
        }

        public DB_E_CommerceContext(DbContextOptions<DB_E_CommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TProduct> TProduct { get; set; }
        public virtual DbSet<TProductBrand> TProductBrand { get; set; }
        public virtual DbSet<TProductType> TProductType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DB_E_Commerce;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.ToTable("T_Product");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PicturePath).HasMaxLength(300);

                entity.HasOne(d => d.ProductBrand)
                    .WithMany(p => p.TProduct)
                    .HasForeignKey(d => d.ProductBrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_Product__Produ__286302EC");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.TProduct)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__T_Product__Produ__276EDEB3");
            });

            modelBuilder.Entity<TProductBrand>(entity =>
            {
                entity.ToTable("T_ProductBrand");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TProductType>(entity =>
            {
                entity.ToTable("T_ProductType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
