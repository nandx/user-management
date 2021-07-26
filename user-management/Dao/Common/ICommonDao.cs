using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Antlr.Runtime.Misc;
using NHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Dao.Common
{
    public interface ICommonDao<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();

        IList<TEntity> GetAllList();

        Task<TEntity> GetById(int id);

        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(TEntity entity);
    }
}