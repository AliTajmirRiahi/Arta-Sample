using Arta.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Application.CatalogHandlers
{
    public class CatalogFactory
    {
        public static Catalog CreateCatalog(string title, string description, int consumerId)
        {

            Catalog catalog = new Catalog()
            {
                Title = title,
                Description = description,
                ConsumerId = consumerId
            };

            return catalog;
        }

        public static Catalog UpdateCatalog(Catalog catalog, string title, string description)
        {
            catalog.Title = title;
            catalog.Description = description;

            return catalog;
        }
    }
}
