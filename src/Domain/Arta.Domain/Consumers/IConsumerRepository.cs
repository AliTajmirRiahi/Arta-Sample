using Arta.Framework.Application;
using Arta.Domain.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Consumers
{
    public interface IConsumerRepository : IRepository
    {
        Task<int> CreateConsumer(Consumer consumer);
        Task<bool> IsSubDoaminDuplicate(string subDomain);
    }
}
