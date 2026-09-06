using Microsoft.AspNetCore.Http;
using NTTV.Domain.Shared.Exceptions;

namespace NTTV.Domain.Customer.Exceptions;

public class InvalidPhoneNumberException(string message) : DomainException(message, StatusCodes.Status400BadRequest)
{
}
