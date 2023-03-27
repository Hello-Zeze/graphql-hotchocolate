using ES.Api.Models;
using Nest;

namespace ES.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddESDeps(this IServiceCollection services)
        {
            var esUrl = Environment.GetEnvironmentVariable("ES_URI");
            var defaultIndex = Environment.GetEnvironmentVariable("ES_INDEX_NAME");

            var settings = new ConnectionSettings(new Uri(esUrl)).PrettyJson().DefaultIndex(defaultIndex);
            AddDefaultMappings(settings);

            var esClient = new ElasticClient(settings);
            CreateIndex(esClient, defaultIndex);

            services.AddSingleton<IElasticClient>(esClient);

            return services;
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Product>(p => 
                p.Ignore(x => x.Price)
                 .Ignore(x => x.Quantity)
                 .Ignore(x => x.Id)
            );            
        }

        private static void CreateIndex(IElasticClient elasticClient, string indexName)
        {
            elasticClient.Indices.Create(indexName, i => i.Map<Product>(x => x.AutoMap()));
        }
    }
}
