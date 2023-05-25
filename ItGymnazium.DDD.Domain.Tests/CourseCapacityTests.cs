using ItGymnazium.DDD.Domain.ValueObjects;

namespace ItGymnazium.DDD.Domain.Tests;

public class CourseCapacityTests
{
    [Test]
    public void Creating_instance_with_value_less_than_min_value_throws()
    {
        // Arrange
        var lowerThanMinValue = CourseCapacity.MinValue - 1;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new CourseCapacity(lowerThanMinValue));
    }

    // TODO: write more tests here
}