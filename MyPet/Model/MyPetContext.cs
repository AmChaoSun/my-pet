using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyPet.Model
{
    public partial class MyPetContext : DbContext
    {
        public MyPetContext()
        {
        }

        public MyPetContext(DbContextOptions<MyPetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=MyPet;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.WeightRateToFeed).HasColumnType("numeric(3,2)");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("Owner");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.ForNpgsqlHasComment("Account Table for login infomation");

                entity.HasIndex(e => e.Email)
                    .HasName("User_Email_key")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("User_UserName_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("nextval('\"Account_Id_seq\"'::regclass)");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.HasSequence<int>("Account_Id_seq");
        }
    }
}
