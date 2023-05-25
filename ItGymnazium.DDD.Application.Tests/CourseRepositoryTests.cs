using ItGymnazium.DDD.Application.Persistence;
using ItGymnazium.DDD.Data;
using ItGymnazium.DDD.Domain;
using ItGymnazium.DDD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ItGymnazium.DDD.Application.Tests;

public class CourseRepositoryTests
{
    private SchoolDbContext _dbContext;
    private CourseRepository _courseRepository;

    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddDbContext<SchoolDbContext>(b => b.UseInMemoryDatabase("School"));
        var serviceProvider = services.BuildServiceProvider();
        _dbContext = serviceProvider.GetRequiredService<SchoolDbContext>();
        _courseRepository = new CourseRepository(_dbContext);
    }

    [Test]
    public async Task Course_can_be_added_and_loaded()
    {
        // Arrange
        var student = new Student("John", "Smith", new DateOnly(2000, 1, 1), new EmailAddress("john@smith.com"));

        var course = new Course(new CourseCapacity(10));
        course.EnrollStudent(student);

        _courseRepository.Add(course);
        await _dbContext.SaveChangesAsync();

        // Act
        var loadedCourse = await _courseRepository.GetById(course.Id);

        // Assert
        Assert.That(loadedCourse, Is.Not.Null);
        Assert.That(loadedCourse.Capacity.Value, Is.EqualTo(10));
        Assert.That(loadedCourse.Enrollments.Count, Is.EqualTo(1));
    }
}