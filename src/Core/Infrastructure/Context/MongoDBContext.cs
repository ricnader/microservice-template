using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Infrastructure.Contracts;

namespace Infrastructure.Context
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;


        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }

        public MongoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);
            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);

            // Conventions
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };

            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func) => _commands.Add(func);

    }
}
