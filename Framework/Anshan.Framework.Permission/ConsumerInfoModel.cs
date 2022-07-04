using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anshan.Framework.Permission
{
    public class ConsumerInfoModel
    {
        private readonly string _user;
        public ConsumerInfoModel()
        {

        }

        public ConsumerInfoModel(int consumerId, string subDomain, string themeName, string user)
        {
            ConsumerId = consumerId;
            SubDomain = subDomain;
            ThemeName = themeName;
            _user = user;
        }

        public int ConsumerId { get; private set; }
        public string SubDomain { get; set; }
        public string ThemeName { get; set; }

        public T GetUser<T>()
        {
            return JsonConvert.DeserializeObject<T>(_user);
        }
    }
}
