using ItGymnazium.DDD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItGymnazium.DDD.Data;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentEntity>(student =>
        {
            student.ToTable("Student");
            student.HasKey(s => s.Id);
            student.Property(s => s.FirstName).HasMaxLength(50);
            student.Property(s => s.LastName).HasMaxLength(50);
            student.Property(s => s.EmailAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<CourseEntity>(course =>
        {
            course.ToTable("Course");
            course.HasKey(c => c.Id);
            course.HasMany<EnrollmentEntity>(c => c.Enrollments).WithOne(e => e.Course);
            course.Navigation(c => c.Enrollments).AutoInclude();
        });

        modelBuilder.Entity<EnrollmentEntity>(enrollment =>
        {
            enrollment.ToTable("Enrollment");
            enrollment.HasKey(e => e.Id);
        });
    }
}