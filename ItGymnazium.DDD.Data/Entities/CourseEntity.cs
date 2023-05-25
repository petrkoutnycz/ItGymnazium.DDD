namespace ItGymnazium.DDD.Data.Entities;

public class CourseEntity
{
    public Guid Id { get; set; }
    public int Capacity { get; set; }
    public List<EnrollmentEntity> Enrollments { get; set; } = new();
}

public class EnrollmentEntity
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public CourseEntity Course { get; set; }
    public Guid StudentId { get; set; }
    public DateTime CreatedUtc { get; set; }
}
