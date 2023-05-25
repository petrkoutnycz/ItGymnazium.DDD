namespace ItGymnazium.DDD.Domain;

public sealed class Enrollment
{
    public Guid Id { get; }
    public StudentId StudentId { get; }
    public DateTime CreatedUtc { get; }

    public Enrollment(StudentId studentId)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        CreatedUtc = DateTime.UtcNow;
    }

    internal Enrollment(Guid id, StudentId studentId, DateTime createdUtc)
    {
        Id = id;
        StudentId = studentId;
        CreatedUtc = DateTime.SpecifyKind(createdUtc, DateTimeKind.Utc);
    }
}