using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserDetailSystem.Models
{
    public partial class UserDBContext : DbContext
    {
        public virtual DbSet<UserTb> UserTb { get; set; }

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTB");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephoneno)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
