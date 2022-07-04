using System;
using System.Threading.Tasks;

namespace Anshan.Framework.Permission
{
    public interface IConsumer
    {
        ConsumerInfoModel GetConsumerInfo();
        Task<ConsumerInfoModel> GetConsumerInfoUrl();
    }
}