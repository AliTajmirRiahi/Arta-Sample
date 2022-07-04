using Anshan.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Query.Model.CatalogQueryModel;

namespace Arta.Query.CatalogQueries
{
    public interface ICatalogQueryFacade : IQueryFacade
    {
        Task<CatalogModel> GetCatalogsById(int Id);
    }
}
