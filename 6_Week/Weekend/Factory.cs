using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace DITest
{
    public class DogFactory
    {
        private MySqlOptions _mysqlConfig;
        public DogFactory(IOptions<MySqlOptions> options)
        {
            _mysqlConfig = options.Value;
        }
        internal IDbConnection Connection
        {
            get { return new MySqlConnection(_mysqlConfig.ConnectionString); }
        }
        public List<Dog> GetAllDogs()
        {
            using(IDbConnection dbConnection = Connection)
            {
                return Connection.Query<Dog>("SELECT * FROM dogs").ToList();
            }
        } 
    }
}