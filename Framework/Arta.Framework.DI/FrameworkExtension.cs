using System.Data;
using System.Data.SqlClient;
using Arta.Framework.Application;
using Arta.Framework.Application.Command;
using Arta.Framework.Core;
using Arta.Framework.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Arta.Framework.DI
{
    public static class FrameworkExtension
    {
        public static void AddFramework(this IServiceCollection services, string connectionStringKey)
        {
            services.AddScoped<IServiceLocator, DotNetCoreServiceLocatorAdapter>();

            services.AddBus();
            services.AddEventAggregator();

            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionStringKey));
        }
        
        public static void AddCommandHandlers<T>(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<T>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<T>()
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        public static void AddQueryFacades<T>(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<T>()
                .AddClasses(classes => classes.AssignableTo<IQueryFacade>())
                .AsMatchingInterface()
                .WithScopedLifetime());
        }

        
        public static void AddFacades<T>(this IServiceCollection services)
        {
            //services.Scan(scan => scan
            //    .FromAssemblyOf<T>()
            //    .AddClasses(classes => classes.AssignableTo<IFacade>())
            //    .AsMatchingInterface()
            //    .WithScopedLifetime());
        }

        public static void AddRepositories<T>(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<T>()
                .AddClasses(classes => classes.AssignableTo<IRepository>())
                .AsMatchingInterface()
                .WithScopedLifetime());
        }
    }
}