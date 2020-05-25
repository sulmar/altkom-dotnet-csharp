using System.Collections.Generic;

namespace Altkom.CSharp.IServices
{

    // interfejs generyczny
    public interface IEntityService<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
