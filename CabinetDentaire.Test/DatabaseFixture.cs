using CabinetDentaire.Postgresql;
using Postgresql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Test
{
    public class DatabaseFixture : IDisposable
    {
        
       public IPostgreSqlServices _postgreSqlSerives { get; private set; }

        IBuildPostgreSqlConnection _buildPostgreSqlConnection;

        public DatabaseFixture()
        {
            var postgreSqlConfiguration = new PostgreSqlConfiguration
            {
                Host = "localhost",
                Port = 5432,
                UserName = "postgres",
                Password = "root",
                Database = "cabinetdentaitedb"
            };
            _buildPostgreSqlConnection = new PostgreSqlConnectionFactory(postgreSqlConfiguration);
            _postgreSqlSerives = new PostgreSqlServices(_buildPostgreSqlConnection);
        }

        public void Dispose()
        {
            
        }
    }
}
