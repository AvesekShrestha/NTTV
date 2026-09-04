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
  }

  public void UpdateEmail(string email)
  {
    Email = Email.Create(email);
  }

  public void ChangePassword(string password)
  {
    Password = Password.Create(password);
  }
}
