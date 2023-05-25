using ItGymnazium.DDD.BadDesign.WebApi.DTOs;
using ItGymnazium.DDD.Data;
using ItGymnazium.DDD.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ItGymnazium.DDD.BadDesign.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly SchoolDbContext _dbContext;

    public CourseController(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddCourseDto courseDto, CancellationToken cancellationToken)
    {
        // if (courseDto.Capacity < 5 || courseDto.Capacity > 1000)
        // {
        //     throw new ArgumentOutOfRangeException();
        // }

        var courseEntity = new CourseEntity
        {
            Id = Guid.NewGuid(),
            Capacity = courseDto.Capacity
        };

        courseEntity.Enrollments.AddRange(
            courseDto.Enrollments.Select(e => new EnrollmentEntity
            {
                Id = Guid.NewGuid(),
                Course = courseEntity,
                CourseId = courseEntity.Id,
                StudentId = e.StudentId,
                CreatedUtc = e.CreatedUtc
            }));

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}