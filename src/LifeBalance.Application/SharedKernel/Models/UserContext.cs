using LifeBalance.Application.SharedKernel.Abstractions;

namespace LifeBalance.Application.SharedKernel.Models;

public class UserContext : IUserContext
{
    public Guid Id { get; private set; }
    public string Email { get;  private set;}
    public string Name { get; private set; }
    public string Language { get; private set; }
    
    public IUserContext SetId(Guid id)
    {
        Id = id;
        return this;
    }

    public IUserContext SetEmail(string email)
    {
        Email = email;
        return this;
    }

    public IUserContext SetName(string name)
    {
        Name = name;
        return this;
    }

    public IUserContext SetLanguage(string language)
    {
        Language = language;
        return this;
    }
}