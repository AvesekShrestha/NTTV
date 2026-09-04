using System.Net.Mail;

namespace NTTV.Domain.User.ValueObjects;

public class Email
{

  public string Value { get; private set; }

  protected Email(string value)
  {
    Value = value;
  }

  public static Email Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Email can't be empty");

    MailAddress? address = new(value);
    if (address.Address != value) throw new ArgumentException("Invalid email address");

    return new Email(value);
  }
}
