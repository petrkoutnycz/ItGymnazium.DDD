using ItGymnazium.DDD.Domain.ValueObjects;

namespace ItGymnazium.DDD.Domain;

public readonly record struct StudentId(Guid Value)
{
    public StudentId() : this(Guid.NewGuid())
    {
    }
}

public sealed class Student : IEquatable<Student>
{
    public StudentId StudentId { get; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly DateOfBirth { get; }
    public EmailAddress EmailAddress { get; }

    public Student(string firstName, string lastName, DateOnly dateOfBirth, EmailAddress emailAddress)
    {
        StudentId = new StudentId();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        EmailAddress = emailAddress;
    }

    internal Student(StudentId studentId, string firstName, string lastName, DateOnly dateOfBirth, EmailAddress emailAddress)
    {
        StudentId = studentId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public void SetName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool Equals(Student? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return StudentId.Equals(other.StudentId);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Student other && Equals(other);
    }

    public override int GetHashCode()
    {
        return StudentId.GetHashCode();
    }
}