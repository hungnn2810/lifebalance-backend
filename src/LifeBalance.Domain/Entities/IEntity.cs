namespace LifeBalance.Domain.Entities;

public interface IEntity<out T>
{
    T Id { get; }
}