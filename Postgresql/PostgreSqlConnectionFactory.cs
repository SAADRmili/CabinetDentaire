using CabinetDentaire.Postgresql;
using Npgsql;

namespace Postgresql
{
    public class PostgreSqlConnectionFactory : IBuildPostgreSqlConnection
    {
        private readonly NpgsqlConnectionStringBuilder _connectionString;
        public PostgreSqlConnectionFactory(PostgreSqlConfiguration postgreSqlConfiguration)
        {
            var configuration = postgreSqlConfiguration;
            _connectionString = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.Host,
                Port = configuration.Port,
                Username = configuration.UserName,
                Password = configuration.Password,
                Database = configuration.Database,
            };
        }
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);

        }
    }
}
