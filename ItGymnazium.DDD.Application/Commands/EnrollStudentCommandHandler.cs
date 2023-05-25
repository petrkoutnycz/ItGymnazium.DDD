using ItGymnazium.DDD.Application.Persistence;
using ItGymnazium.DDD.Domain;

namespace ItGymnazium.DDD.Application.Commands;

public sealed record EnrollStudentCommand(StudentId StudentId, CourseId CourseId)
{
}

public class EnrollStudentCommandHandler
{
    private readonly CourseRepository _courseRepository;
    private readonly StudentRepository _studentRepository;

    public EnrollStudentCommandHandler(CourseRepository courseRepository, StudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
    }

    public async Task HandleAsync(EnrollStudentCommand command)
    {
        var course = await _courseRepository.GetById(command.CourseId)
                     ?? throw new CourseNotFoundException(command.CourseId);

        var student = await _studentRepository.GetById(command.StudentId)
                      ?? throw new StudentNotFoundException(command.StudentId);

        course.EnrollStudent(student);

        // TODO: save changes
    }
}

public sealed class CourseNotFoundException : ApplicationException
{
    public CourseNotFoundException(CourseId courseId)
        : base($"Course with id {courseId} was not found")
    {
    }
}

public sealed class StudentNotFoundException : ApplicationException
{
    public StudentNotFoundException(StudentId studentId)
        : base($"Student with id {studentId} was not found")
    {
    }
}