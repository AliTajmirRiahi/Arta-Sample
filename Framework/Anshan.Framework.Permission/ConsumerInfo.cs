using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Anshan.Framework.Permission
{
    public class ConsumerInfo : IConsumer
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConsumerInfo(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            return userId;
        }

        public string GetClientId()
        {
            var client = _httpContextAccessor.HttpContext.User
                .Claims.FirstOrDefault(c => c.Type == "client_id");
            return client?.Value;
        }

        public ConsumerInfoModel GetConsumerInfo()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user == null)
                return null;
            return new ConsumerInfoModel(
                int.Parse(user.Claims.FirstOrDefault(x => x.Type == "consumerId")?.Value),
                user.Claims.FirstOrDefault(x => x.Type == "subDomain")?.Value,
                user.Claims.FirstOrDefault(x => x.Type == "ThemeName")?.Value,
                user.Claims.FirstOrDefault(x => x.Type == "user")?.Value
                );
        }

        public Task<ConsumerInfoModel> GetConsumerInfoUrl()
        {
            throw new NotImplementedException();
        }
    }
}