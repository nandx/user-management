using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using user_management.Model;

namespace user_management.Dao.Impl
{
    public class AppUserDaoImpl : IAppUserDao
    {
        
        private readonly ISession _session;
        private ITransaction _transaction;

        public AppUserDaoImpl(ISession session)
        {
            _session = session;
        }
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(AppUser entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public Task Delete(AppUser entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<AppUser> Appusers { get; }
    }
}