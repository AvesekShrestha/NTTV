using NTTV.Application.Common.Interfaces;

namespace NTTV.Infrastructure.Identity;

public sealed class IdGenerator : IIdGenerator
{
  public string GenerateId()
  {
    return Guid.NewGuid().ToString();
  }
}
