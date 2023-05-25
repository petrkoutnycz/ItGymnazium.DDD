using ItGymnazium.DDD.BadDesign.WebApi.DTOs;
using ItGymnazium.DDD.Domain.ValueObjects;

namespace ItGymnazium.DDD.BadDesign.WebApi.Services;

public class CourseService
{
    public Task Add(AddCourseDto courseDto)
    {
        // TODO: move logic here

        // if (courseDto.Capacity < 5 || courseDto.Capacity > 1000)
        // {
        //     throw new ArgumentOutOfRangeException();
        // }

        return Task.CompletedTask;
    }

    public void SetCourseCapacity(int newCapacity)
    {
        if (newCapacity > 5)
            throw new ArgumentOutOfRangeException();


    }

    public void SetCourseCapacity(CourseCapacity newCapacity)
    {

    }

    public void DeleteEnrollmentWithEmail(string emailAddress)
    {
        // if (string.IsNullOrEmpty(emailAddress))
        //     throw ArgumentNullException();

        if (!IsValidEmail(emailAddress))
            throw new ArgumentException();


    }

    private bool IsValidEmail(string email)
    {
        // TODO: logic goes here
        return true;
    }
}