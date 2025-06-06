using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Models;

namespace SchoolManagement.Infrastructure.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StudentId).IsRequired();
                entity.HasIndex(e => e.StudentId).IsUnique();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teachers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TeacherId).IsRequired();
                entity.HasIndex(e => e.TeacherId).IsUnique();
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("Classrooms");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoomNumber).IsRequired();
                entity.HasIndex(e => e.RoomNumber).IsUnique();

                entity.HasMany(e => e.Students)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ClassroomStudents"));

                entity.HasMany(e => e.Teachers)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("ClassroomTeachers"));
            });
        }
    }
}