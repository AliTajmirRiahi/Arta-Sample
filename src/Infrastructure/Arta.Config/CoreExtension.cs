using Arta.Framework.DI;
using Arta.Application.ConsumerHandlers;
using Arta.Persistence.EF.Repositories;
using Arta.Query.CunsumerQueries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arta.Config
{
    public static class CoreExtension
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFramework(configuration["ConnectionStrings:DefaultConnection"]);

            services.AddRepositories<ConsumerRepository>();

            services.AddCommandHandlers<CreateConsumerHandler>();

            services.AddQueryFacades<ConsumerQueryFacade>();
        }
    }
}