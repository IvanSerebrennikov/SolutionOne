namespace SO.Domain.DataAccessInterfaces.Entity
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}