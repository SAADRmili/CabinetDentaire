namespace CabinetDentaire.Postgresql
{
    public interface IPostgreSqlServices
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null);

        Task<int> ExecuteAsync(string sql, object parameters = null);

        Task<bool> ExecuteScalarAsync(string sql, object parameters = null);

        //FOR JOIN 
        Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, string splitOn = "Id");

        Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TReturn>(string sql, Func<TFirst, TSecond, TThired, TReturn> map, object param = null, string splitOn = "Id");

        Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThired, TFourth, TReturn> map, object param = null, string splitOn = "Id");

        Task<IEnumerable<TReturn>> QueryMultiAsync<TFirst, TSecond, TThired, TFourth, TFive, TReturn>(string sql, Func<TFirst, TSecond, TThired, TFourth, TFive, TReturn> map, object param = null, string splitOn = "Id");
    }
}
