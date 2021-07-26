using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Antlr.Runtime.Misc;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Mapping;
using user_management.Model.Entity;

namespace user_management.Dao.Common
{
    public class CommonDaoImpl<TEntity> : ICommonDao<TEntity> where TEntity : class, IEntity
    {
        private readonly ISession _session;

        public CommonDaoImpl(ISession session)
        {
            _session = session;
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IList<TEntity> GetAllList()
        {
            return (IList<TEntity>) _session.CreateCriteria<TEntity>().SetFirstResult(0).SetMaxResults(10).List();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            throw new System.NotImplementedException();
        }

        public Task Create(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}