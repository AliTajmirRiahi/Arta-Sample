using Arta.Query.Model.CatalogQueryModel;
using Arta.Query.Model.ConsumerQueryModel;
using Dapper;
using Domain.Models.Users;
using Framework.Exceptions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arta.Query.CunsumerQueries
{
    public class ConsumerQueryFacade : IConsumerQueryFacade
    {
        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public ConsumerQueryFacade(IDbConnection connection, IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }

        public async Task<ConsumerPermissionModel> GetCunsumerByDomain(string domain)
        {
            string query = $@"SELECT c.Id,
                                  c.Title,
                                  c.[Description], 
                                  c.SubDomain,
                                  c.HaveDomain,
                                  c.Domain,
                                  c.ExpireDomain,
                                  c.RegisterDomain,
                                  c.CreatedAt,
                                  c.[ExpireDate], 
                                  c.RegisterSource,
                                  c.[Enable], 
                                  c.[Language],
                                  c.ThemeName
                                  FROM Consumers c 
                                  WHERE c.[Enable] = 1 
                                  AND (
                                        c.SubDomain = '{domain}' 
                                        OR
                                        (c.HaveDomain = 1 AND c.Domain = '{domain}') 
                                  )";
            return await _connection.QueryFirstOrDefaultAsync<ConsumerPermissionModel>(query);
        }

        public async Task<List<ConsumerPermissionModel>> GetCunsumers(string memberShipId, string domain)
        {
            string query = $@"SELECT c.Id,
                              c.Title,
                              c.[Description], 
                              c.SubDomain,
                              c.HaveDomain,
                              c.Domain,
                              c.ExpireDomain,
                              c.RegisterDomain,
                              c.CreatedAt,
                              c.[ExpireDate], 
                              c.RegisterSource,
                              c.[Enable], 
                              c.[Language],
                              c.ThemeName
                              FROM Consumers c
                              JOIN ConsumerUser cu ON c.Id = cu.ConsumerId
                              JOIN SystemUsers su ON cu.UserId = su.Id
                              WHERE c.[Enable] = 1 AND cu.IsAdmin = 1  
                              AND su.MembershipId = '{memberShipId}'
                              {(string.IsNullOrEmpty(domain) ? "" : $@"AND (
                                                                        c.SubDomain = '{domain}' 
                                                                        OR
                                                                        (c.HaveDomain = 1 AND c.Domain = '{domain}') 
                                                                    )")}";
            return (await _connection.QueryAsync<ConsumerPermissionModel>(query)).ToList();
        }


        public async Task<int> GetConsumerCountBySysUserId(int sysUserId)
        {
            string query = $@"SELECT COUNT(*)
                              FROM ConsumerUser cu
                              WHERE cu.IsAdmin = 1 AND
                                    cu.UserId = {sysUserId}";

            return await _connection.ExecuteScalarAsync<int>(query);
        }

        public async Task<bool> IsExitSubDomain(string subDomain)
        {
            string query = $@"SELECT COUNT(*)
                              FROM Consumers c
                              WHERE c.SubDomain = N'{subDomain.ToLower()}'";

            return await _connection.ExecuteScalarAsync<int>(query) > 0;
        }

        public async Task<ConsumerPermissionModel> GetCunsumersById(int Id)
        {
            string query = $@"SELECT c.Id,
                                  c.Title,
                                  c.[Description], 
                                  c.SubDomain,
                                  c.HaveDomain,
                                  c.Domain,
                                  c.ExpireDomain,
                                  c.RegisterDomain,
                                  c.CreatedAt,
                                  c.[ExpireDate], 
                                  c.RegisterSource,
                                  c.[Enable], 
                                  c.[Language],
                                  c.ThemeName
                                  FROM Consumers c 
                                  WHERE c.[Enable] = 1 
                                  AND c.Id = {Id}" ;

            return await _connection.QueryFirstOrDefaultAsync<ConsumerPermissionModel>(query);
        }

        public async Task<IEnumerable<CatalogModel>> GetCunsumerCatalogsById(int Id)
        {
            string query = $@"SELECT 
                                c.Id,
                                c.Title,
                                c.Description 
                                FROM Catalogs c 
                                WHERE c.ConsumerId = {Id}";

            return await _connection.QueryAsync<CatalogModel>(query);
        }
    }
}
