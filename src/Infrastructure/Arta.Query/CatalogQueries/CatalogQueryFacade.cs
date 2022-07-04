using Framework.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arta.Query.Model.CatalogQueryModel;
using Dapper;

namespace Arta.Query.CatalogQueries
{
    public class CatalogQueryFacade : ICatalogQueryFacade
    {
        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public CatalogQueryFacade(IDbConnection connection,IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }

        public async Task<CatalogModel> GetCatalogsById(int Id)
        {
            string query = $@"SELECT 
                                c.Id,
                                c.Title,
                                c.Description 
                                FROM Catalogs c 
                                WHERE c.Id = {Id}";

            return await _connection.QueryFirstOrDefaultAsync<CatalogModel>(query);
        }
    }
}
