using Microsoft.AspNetCore.Http;
using NTTV.Domain.Shared.Exceptions;

namespace NTTV.Domain.Pool.Exceptions;

public sealed class AgentNotfoundInPoolException(string message) : DomainException(message, StatusCodes.Status404NotFound)
{
}
