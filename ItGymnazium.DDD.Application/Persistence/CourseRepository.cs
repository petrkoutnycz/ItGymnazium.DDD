using ItGymnazium.DDD.Data;
using ItGymnazium.DDD.Data.Entities;
using ItGymnazium.DDD.Domain;
using ItGymnazium.DDD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ItGymnazium.DDD.Application.Persistence;

public class CourseRepository
{
    private readonly SchoolDbContext _dbContext;

    public CourseRepository(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Course?> GetById(CourseId courseId, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<CourseEntity>().SingleOrDefaultAsync(c => c.Id == courseId.Value, cancellationToken);

        if (entity != null)
        {
            return new Course(new CourseId(entity.Id), new CourseCapacity(entity.Capacity),
                entity.Enrollments.Select(e => new Enrollment(e.Id, new StudentId(e.StudentId), e.CreatedUtc)));
        }

        return null;
    }

    public void Add(Course course)
    {
        var courseEntity = new CourseEntity
        {
            Id = course.Id.Value,
            Capacity = course.Capacity.Value
        };

        foreach (var enrollment in course.Enrollments)
        {
            courseEntity.Enrollments.Add(new EnrollmentEntity
            {
                Id = enrollment.Id,
                Course = courseEntity,
                CourseId = courseEntity.Id,
                StudentId = enrollment.StudentId.Value,
                CreatedUtc = enrollment.CreatedUtc
            });
        }

        _dbContext.Set<CourseEntity>().Add(courseEntity);
    }
}