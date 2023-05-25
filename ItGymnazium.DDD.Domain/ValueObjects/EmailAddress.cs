namespace ItGymnazium.DDD.Domain.ValueObjects;

public readonly struct EmailAddress : IEquatable<EmailAddress>, IComparable<EmailAddress>
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        // check for format
        if (IsValid(value))
        {
            Value = value;
        }
        else
        {
            throw new ArgumentException("Invalid e-mail address", nameof(value));
        }
    }

    private static bool IsValid(string email)
    {

        // TODO: verify with regex
        return true;
    }

    public int CompareTo(EmailAddress other)
    {
        return string.Compare(Value, other.Value, StringComparison.Ordinal);
    }

    public bool Equals(EmailAddress other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EmailAddress other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}