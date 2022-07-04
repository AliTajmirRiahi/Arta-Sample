using System.Threading.Tasks;

namespace Arta.Framework.Core
{
    public interface IUnitOfWork
    {
        void Begin();

        Task Commit();

        void Rollback();
    }
}