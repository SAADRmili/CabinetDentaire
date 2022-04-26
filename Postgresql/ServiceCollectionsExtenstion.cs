using CabinetDentaire.Postgresql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Postgresql
{
    public static class ServiceCollectionsExtenstion
    {
        public static IServiceCollection UsePostgreSql(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            return services.Configure<PostgreSqlConfiguration>(configurationSection)
                .AddTransient<IBuildPostgreSqlConnection, PostgreSqlConnectionFactory>()
                .AddTransient<IPostgreSqlServices, PostgreSqlServices>()
                .AddTransient(x => x.GetService<IOptions<PostgreSqlConfiguration>>().Value);
        }
    }
}
