using System.Linq;
using System.Threading.Tasks;
using user_management.Model;

namespace user_management.Dao
{
    public interface IAppUserDao
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();

        Task Save(AppUser entity);
        Task Delete(AppUser entity);

        IQueryable<AppUser> Appusers { get; }
    }
}