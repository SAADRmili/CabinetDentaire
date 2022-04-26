using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDentaire.Postgresql
{
  
    public interface IBuildPostgreSqlConnection
    {
        NpgsqlConnection GetConnection();
    }
}
