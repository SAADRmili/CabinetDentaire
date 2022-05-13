using Npgsql;

namespace CabinetDentaire.Postgresql
{
    public interface IBuildPostgreSqlConnection
    {
        NpgsqlConnection GetConnection();
    }
}
