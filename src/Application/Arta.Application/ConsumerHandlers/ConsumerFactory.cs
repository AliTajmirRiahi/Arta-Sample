using Arta.Application.Contracts.ConsumerCommand;
using Arta.Domain.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.ConsumerHandlers
{
    public class ConsumerFactory
    {
        public static Consumer CreateConsumerForm(CreateConsumerCommand command, int userFreeDay, string newUserThemeName)
        {
            Consumer consumer = new Consumer()
            {
                SubDomain = command.SubDomain,
                Title = command.SubDomain,
                ExpireDate = DateTime.Now.AddDays(userFreeDay),
                Language = command.Language,
                RegisterSource = command.RegisterSource,
                ThemeName = newUserThemeName,
            };

            return consumer;
        }
    }
}
