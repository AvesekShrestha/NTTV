using NTTV.Domain.Shared;
using NTTV.Domain.User.Exceptions;

namespace NTTV.Domain.User.ValueObjects;

public class Username : ValueObject
{

  public string Value { get; private set; }

  protected Username(string value)
  {
    Value = value;
  }

  public static Username Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new InvalidUsernameException("Username can't be empty");
    if (value.Length < 3) throw new InvalidUsernameException("Username must be at least 3 characters long");
    return new Username(value);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
