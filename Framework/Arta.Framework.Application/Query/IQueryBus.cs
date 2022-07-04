using System.Threading.Tasks;

namespace Arta.Framework.Application.Query
{
    public interface IQueryBus
    {
        Task<T> Dispatch<T>(IQuery<T> query);
    }
}