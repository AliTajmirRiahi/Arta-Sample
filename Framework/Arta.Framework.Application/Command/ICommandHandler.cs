using System.Threading.Tasks;

namespace Arta.Framework.Application.Command
{
    public interface ICommandHandler<in T>
    {
        Task Handle(T command);
    }
    
    public interface ICommandHandler<in TCommand, TResponse>
    {
        Task<TResponse> Handle(TCommand command);
    }
}