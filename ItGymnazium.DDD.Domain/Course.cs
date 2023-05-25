using ItGymnazium.DDD.Domain.ValueObjects;

namespace ItGymnazium.DDD.Domain;

public readonly record struct CourseId(Guid Value)
{
    public CourseId() : this(Guid.NewGuid())
    {
    }
}

public sealed class Course
{
    private readonly List<Enrollment> _enrollments;

    public CourseId Id { get; }
    public CourseCapacity Capacity { get; }

    // IMPORTANT: do not expose full list
    public IReadOnlyList<Enrollment> Enrollments => _enrollments.AsReadOnly();

    public Course(CourseCapacity capacity)
    {
        Id = new CourseId();
        Capacity = capacity;
        _enrollments = new List<Enrollment>();
    }

    internal Course(CourseId courseId, CourseCapacity capacity, IEnumerable<Enrollment> enrollments)
    {
        Id = courseId;
        Capacity = capacity;
        _enrollments = new List<Enrollment>(enrollments);
    }

    /// <exception cref="StudentAlreadyEnrolledException">Thrown when a student is already enrolled</exception>
    /// <exception cref="CourseFullyEnrolledException" />
    public void EnrollStudent(Student student)
    {
        // check if already enrolled
        if (_enrollments.Any(e => e.StudentId == student.StudentId))
        {
            // throw new Exception("Student is already enrolled");
            throw new StudentAlreadyEnrolledException(student, this);
        }

        // check for capacity
        if (_enrollments.Count >= Capacity.Value)
        {
            throw new CourseFullyEnrolledException(this);
        }

        var enrollment = new Enrollment(student.StudentId);
        _enrollments.Add(enrollment);
    }
}

public sealed class StudentAlreadyEnrolledException : ApplicationException
{
    internal StudentAlreadyEnrolledException(Student student, Course course)
        : base($"Student {student.StudentId} is already enrolled in course {course.Id}")
    {
    }
}

public sealed class CourseFullyEnrolledException : ApplicationException
{
    internal CourseFullyEnrolledException(Course course)
        : base($"Course {course.Id} already reached its capacity ({course.Capacity})")
    {
    }
}