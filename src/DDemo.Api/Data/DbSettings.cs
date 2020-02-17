using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;

namespace DDemo.Data
{
    public class DbSettings : ILinqToDBSettings
    {
        private readonly string _connectionString;
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "Ddemo";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "Ddemo",
                        ProviderName = "PostgreSQL",
                        ConnectionString = _connectionString,
                    };
            }
        }

        public DbSettings(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}