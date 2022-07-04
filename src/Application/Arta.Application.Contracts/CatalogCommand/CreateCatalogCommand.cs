using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.Contracts.CatalogCommand
{
    public class CreateCatalogCommand
    {
        public CreateCatalogCommand()
        {

        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ConsumerId { get; set; }
    }
}
