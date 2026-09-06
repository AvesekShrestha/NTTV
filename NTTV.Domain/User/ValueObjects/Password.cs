using NTTV.Domain.Shared;
using NTTV.Domain.User.Exceptions;

namespace NTTV.Domain.User.ValueObjects;

public class Password : ValueObject
{

  public string Value { get; private set; }

  protected Password(string value)
  {
    Value = value;
  }

  public static Password Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new InvalidPassowrdException("Password can't be whitespace or null");
    return new Password(value);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
