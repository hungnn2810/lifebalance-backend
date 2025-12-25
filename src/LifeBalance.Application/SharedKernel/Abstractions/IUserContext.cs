namespace LifeBalance.Application.SharedKernel.Abstractions;

public interface IUserContext
{
    Guid Id { get; }
    string Email { get; }
    string Name { get; }

    IUserContext SetId(Guid id);
    IUserContext SetEmail(string email);
    IUserContext SetName(string name);
}