using System.Net.Mail;
using NTTV.Domain.Shared;
using NTTV.Domain.User.Exceptions;

namespace NTTV.Domain.User.ValueObjects;

public class Email : ValueObject
{

  public string Value { get; private set; }

  protected Email(string value)
  {
    Value = value;
  }

  public static Email Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new InvalidEmailException("Email can't be whitespace or null");

    MailAddress? address = new(value);
    if (address.Address != value) throw new InvalidEmailException("Invalid Email format");

    return new Email(value);
  }

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
