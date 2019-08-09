namespace Infrastructure.Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create(DataSourceOptions options);
    }
}
