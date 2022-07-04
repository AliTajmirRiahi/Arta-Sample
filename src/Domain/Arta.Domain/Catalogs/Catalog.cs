using Anshan.Framework.Domain;
using Arta.Domain.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Domain.Catalogs
{
    public class Catalog : AggregateRoot<int>
    {
        public Catalog()
        {
            Title = "";
            Description = "";
        }

        public string Title { get; set; }
        public string Description { get; set; }


        public Consumer Consumer { get; set; }
        public int ConsumerId { get; set; }

        public void SetConsumer(Consumer consumer)
        {
            Consumer = consumer;
        }
    }
}
