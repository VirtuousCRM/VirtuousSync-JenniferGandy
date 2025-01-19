using CsvHelper;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace Sync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sync().GetAwaiter().GetResult();
        }

        private static async Task Sync()
        {
            var apiKey = "REPLACE_WITH_API_KEY_PROVIDED";
            var connectionString = "REPLACE_WITH_DB_CONNECTION_STRING";
            var configuration = new Configuration(apiKey);
            var virtuousService = new VirtuousService(configuration);
            var dataAccessRepo = new DataAccessRepository(connectionString);

            var skip = 0;
            var take = 100;
            var maxContacts = 1000;
            var hasMore = true;

            do
            {
                var contacts = await virtuousService.GetContactsAsync(skip, take);
                skip += take;
                await dataAccessRepo.SaveResults(contacts.List);
                hasMore = skip > maxContacts;
            }
            while (!hasMore);
        }
    }
}
