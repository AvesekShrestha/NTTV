using NTTV.Domain.Shared;
using NTTV.Domain.User.Enums;
using NTTV.Domain.User.ValueObjects;

namespace NTTV.Domain.User;

public sealed class UserAggregrate : AggregateRoot<Guid>
{
  public Username Username { get; private set; }
  public Email Email { get; private set; }
  public Password Password { get; private set; }
  public UserRole Role { get; private set; } = UserRole.Customer;
  public UserStatus Status { get; private set; } = UserStatus.Active;
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  private UserAggregrate(Guid id, Username username, Email email, Password passowrd, UserRole role, UserStatus status) : base(id)
  {
    Username = username;
    Email = email;
    Password = passowrd;
    Role = role;
    Status = status;
  }

  public static UserAggregrate Create(Guid id, string username, string email, string passowrd, UserRole role, UserStatus status)
  {
    return new UserAggregrate(id,
                              Username.Create(username),
                              Email.Create(email),
                              Password.Create(passowrd),
                              role,
                              status);
  }

  public void UpdateUsername(string username)
  {
    Username = Username.Create(username);
    UpdatedAt = DateTime.UtcNow;
  }

  public void UpdateEmail(string email)
  {
    Email = Email.Create(email);
    UpdatedAt = DateTime.UtcNow;
  }

  public void ChangePassword(string password)
  {
    Password = Password.Create(password);
    UpdatedAt = DateTime.UtcNow;

  }
}
