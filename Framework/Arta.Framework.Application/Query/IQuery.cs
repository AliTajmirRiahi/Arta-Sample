using System.Threading.Tasks;

namespace Arta.Framework.Application.Query
{
    public interface IQuery<T>
    {
    }

    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}