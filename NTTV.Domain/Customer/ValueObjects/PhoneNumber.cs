using System.Text.RegularExpressions;
using NTTV.Domain.Customer.Exceptions;
using NTTV.Domain.Shared;

namespace NTTV.Domain.Customer.ValueObjects;

public sealed partial class PhoneNumber : ValueObject
{
  private static readonly Regex PhoneRegex =
          PhoneNumberRegex();

  public string Value { get; private set; }

  private PhoneNumber(string value)
  {
    Value = value;
  }

  public static PhoneNumber Create(string value)
  {
    if (string.IsNullOrWhiteSpace(value)) throw new InvalidPhoneNumberException("Phone number can't be empty");
    value = value.Trim();

    if (!PhoneRegex.IsMatch(value))
      throw new InvalidPhoneNumberException("Invalid phone number format.");

    return new PhoneNumber(value);
  }

  [GeneratedRegex(@"^\+?[1-9]\d{1,14}$")]
  private static partial Regex PhoneNumberRegex();

  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
