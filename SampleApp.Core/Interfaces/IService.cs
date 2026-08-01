namespace SampleApp.Core.Interfaces
{
    public interface IService<TEntity>
        where TEntity : class
    {
        bool Create(TEntity entity);
    }
}
