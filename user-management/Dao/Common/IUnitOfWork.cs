using System;
using System.Data;
using System.Threading.Tasks;
using NHibernate;

namespace user_management.Dao.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ITransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task Commit();

        Task Rollback();
    }
}