using MachineCartSystem.Entity.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace MachineCartSystem.Entity
{
    public partial class MachineCartSystemDbContext : DbContext
    {
        public MachineCartSystemDbContext()
        {
        }

        public MachineCartSystemDbContext(DbContextOptions<MachineCartSystemDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<UserDetail> UserDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserDetaildId)
                    .HasName("PK__UserDeta__06F8BA23998FF343");
                entity.ToTable("UserDetail", "Core");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MiddleName).HasMaxLength(500);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
                entity.Property(e => e.RowVersion).IsRowVersion();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
