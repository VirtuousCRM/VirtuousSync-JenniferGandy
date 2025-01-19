using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using Sync.Models;
using System;

namespace Sync
{
    public class DataAccessRepository
    {
        private readonly string _connectionString;

        public DataAccessRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task SaveResults(IEnumerable<AbbreviatedContact> results)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    const string sql = "INSERT INTO contacts (Id, Name, ContactType, ContactName, Address, Email, Phone)" +
                        "Values (@Id, @Name, @ContactType, @ContactName, @Address, @Email, @Phone)";

                    await connection.ExecuteAsync(sql, results);
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);      
            }

        }
    }
}
