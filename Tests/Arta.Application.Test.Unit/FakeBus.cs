using System.Collections.Generic;
using System.Threading.Tasks;
using Arta.Framework.Application.Command;

namespace Arta.Application.Tests.Unit
{
    class FakeBus : IBus
    {
        public readonly List<object> Commands = new List<object>();

        public Task Dispatch<T>(T command)
        {
            Commands.Add(command);
            return Task.CompletedTask;
        }

        public Task DispatchLocal<T>(T command)
        {
            Commands.Add(command);
            return Task.CompletedTask;
        }

        public Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command)
        {
            Commands.Add(command);
            return null;
        }

        public Task<TResponse> DispatchLocal<TCommand, TResponse>(TCommand command)
        {
            Commands.Add(command);
            return null;
        }
    }
}