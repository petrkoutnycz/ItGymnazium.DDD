using System.ComponentModel.DataAnnotations;

namespace ItGymnazium.DDD.BadDesign.WebApi.DTOs;

public class AddCourseDto
{
    public sealed class Enrollment
    {
        public Guid StudentId { get; set; }
        public DateTime CreatedUtc { get; set; }
    }

    [Range(5, 1000)]
    public int Capacity { get; set; }

    public List<Enrollment> Enrollments { get; set; }
}