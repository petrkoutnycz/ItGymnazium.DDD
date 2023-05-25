using ItGymnazium.DDD.Domain.ValueObjects;

namespace ItGymnazium.DDD.Domain.Tests;

public class CourseTests
{
    [Test]
    public void Enrolling_a_student_twice_throws()
    {
        // Arrange
        var course = new Course(new CourseCapacity());
        var student = new Student("John", "Smith", new DateOnly(2000, 12, 31), new EmailAddress("john@smith.com"));
        course.EnrollStudent(student);

        // Act + Assert
        Assert.Throws<StudentAlreadyEnrolledException>(() => course.EnrollStudent(student));
    }
}