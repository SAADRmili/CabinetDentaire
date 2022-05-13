using Dapper;

namespace CabinetDentaire.Postgresql
{
    public class PostgreSqlServices : IPostgreSqlServices
    {
        private readonly IBuildPostgreSqlConnection _buildPostgreSql;
        public PostgreSqlServices(IBuildPostgreSqlConnection buildPostgreSql)
        {
            _buildPostgreSql = buildPostgreSql;
        }
        public async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.ExecuteAsync(sql, parameters);
        }
        public async Task<bool> ExecuteScalarAsync(string sql, object parameters = null)
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return connection.ExecuteScalar<bool>(sql, parameters);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            var data = await connection.QueryAsync<T>(sql, parameters);
            return data.ToList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null)
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);

        }
        public async Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object? param = null, string splitOn = "Id")
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<TFirst, TSecond, TReturn>(sql, map, param, null, true, splitOn);
        }

        public async Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThired, TFourth, TReturn> map, object param = null, string splitOn = null)
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<TFirst, TSecond, TThired, TFourth, TReturn>(sql, map, param, null, true, splitOn);
        }

        public async Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TReturn>(string sql, Func<TFirst, TSecond, TThired, TReturn> map, object param = null, string splitOn = "Id")
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<TFirst, TSecond, TThired, TReturn>(sql, map, param, null, true, splitOn);
        }

        public async Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TFourth, TFive, TReturn>(string sql, Func<TFirst, TSecond, TThired, TFourth, TFive, TReturn> map, object param = null, string splitOn = "Id")
        {
            await using var connection = _buildPostgreSql.GetConnection();
            await connection.OpenAsync();
            return await connection.QueryAsync<TFirst, TSecond, TThired, TFourth, TFive, TReturn>(sql, map, param, null, true, splitOn);
        }
    }
}
