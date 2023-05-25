namespace ItGymnazium.DDD.Domain.ValueObjects;

public readonly struct CourseCapacity : IEquatable<CourseCapacity>, IComparable<CourseCapacity>
{
    public static readonly int MinValue = 1;
    public static readonly int MaxValue = 1000;

    public int Value { get; }

    public CourseCapacity()
    {
        Value = MinValue;
    }

    public CourseCapacity(int value)
    {
        if (value < MinValue)
        {
            throw new ArgumentOutOfRangeException($"Minimum allowed capacity value is {MinValue}");
        }

        if (value > MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Maximum allowed capacity value is {MaxValue}");
        }

        Value = value;
    }

    public bool Equals(CourseCapacity other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is CourseCapacity other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public int CompareTo(CourseCapacity other)
    {
        return Value.CompareTo(other.Value);
    }
}