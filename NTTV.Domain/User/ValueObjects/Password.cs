namespace NTTV.Domain.User.ValueObjects;

public class Password
{

  public string Value { get; private set; }

  protected Password(string value)
  {
    Value = value;
  }

  public static Password Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Password hash can't be empty");
    return new Password(value);
  }
}
