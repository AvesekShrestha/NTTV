using Microsoft.AspNetCore.Http;
using NTTV.Domain.Shared.Exceptions;

namespace NTTV.Domain.Pool.Exceptions;

public sealed class AgentAlreadyInPoolException(string message) : DomainException(message, StatusCodes.Status409Conflict)
{
}
