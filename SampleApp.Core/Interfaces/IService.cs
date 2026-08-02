using SampleApp.Data.Models;

namespace SampleApp.Core.Interfaces
{
    public interface IService<TEntity>
        where TEntity : class, IIdentifiable
    {
        // According to the "Interface Segregation Principle" this method could be moved to a separate interface.
        // Moreover, it `increases` the constraints over the `TEntity` generic parameter.
        IEnumerable<TEntity> GetByIds(IEnumerable<Guid> ids); 

        bool Create(TEntity entity);
    }
}
