namespace NTTV.Domain.User.ValueObjects;

public class Username
{

  public string Value { get; private set; }

  protected Username(string value)
  {
    Value = value;
  }

  public static Username Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Username can't be empty");
    if (value.Length < 3) throw new ArgumentException("Username must be at least 3 characters long");
    return new Username(value);
  }
}
