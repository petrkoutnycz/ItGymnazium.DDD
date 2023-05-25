using ItGymnazium.DDD.Domain;

namespace ItGymnazium.DDD.Application.Persistence;

public class StudentRepository
{
    public Task<Student?> GetById(StudentId studentId)
    {
        return Task.FromResult<Student?>(null);
    }
}