using Neo4j.Driver;

namespace NeoDataAccess.Repository
{
    public class GraphDataAccess : IGraphDataAccess
    {
        private readonly IAsyncSession _session;
        private readonly string _database;

        public GraphDataAccess(IDriver driver)
        {
            _database = "SOME_DB";
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Dictionary<string, object>>> ExecuteReadDictionaryAsync(string query, string returnObjectKey, IDictionary<string, object>? parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> ExecuteReadListAsync(string query, string returnObjectKey, IDictionary<string, object>? parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteReadScalarAsync<T>(string query, IDictionary<string, object>? parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteWriteTransactionAsync<T>(string query, IDictionary<string, object>? parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
