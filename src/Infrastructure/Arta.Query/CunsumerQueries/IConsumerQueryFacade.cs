using Anshan.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Query.Model.ConsumerQueryModel;
using Arta.Query.Model.CatalogQueryModel;

namespace Arta.Query.CunsumerQueries
{
    public interface IConsumerQueryFacade : IQueryFacade
    {
        Task<ConsumerPermissionModel> GetCunsumerByDomain(string domain);
        Task<List<ConsumerPermissionModel>> GetCunsumers(string memberShipId, string domain);
        Task<ConsumerPermissionModel> GetCunsumersById(int Id);
        Task<int> GetConsumerCountBySysUserId(int sysUserId);
        Task<bool> IsExitSubDomain(string subDomain);
        Task<IEnumerable<CatalogModel>> GetCunsumerCatalogsById(int Id);
    }
}
