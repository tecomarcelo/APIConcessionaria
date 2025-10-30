namespace ApiConcessionaria.Infra.Data.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void AddRange(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity Get(Guid id);
    }
}
