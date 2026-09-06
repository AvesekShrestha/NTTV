using Microsoft.AspNetCore.Http;
using NTTV.Domain.Shared.Exceptions;

namespace NTTV.Domain.User.Exceptions;

public class InvalidUsernameException(string message) : DomainException(message, StatusCodes.Status400BadRequest)
{
}
