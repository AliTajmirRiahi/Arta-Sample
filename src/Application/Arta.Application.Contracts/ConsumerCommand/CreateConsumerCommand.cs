using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.Contracts.ConsumerCommand
{
    public class CreateConsumerCommand
    {
        public CreateConsumerCommand()
        {
            Language = Language.fa;
        }
        public string SubDomain { get; set; }
        public string RegisterSource { get; set; }
        public Language Language { get; set; }
    }
}
