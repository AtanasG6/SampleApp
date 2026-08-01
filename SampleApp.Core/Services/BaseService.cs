using SampleApp.Core.Interfaces;
using SampleApp.Data.Repositories;

namespace SampleApp.Core.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected IRepository<TEntity> Repository { get; }

        protected BaseService(IRepository<TEntity> repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool Create(TEntity entity)
        {
            if(!this.IsValid(entity)) return false;

            this.Repository.Create(entity);
            return true;
        }

        protected virtual bool IsValid(TEntity entity) => true;
    }
}
