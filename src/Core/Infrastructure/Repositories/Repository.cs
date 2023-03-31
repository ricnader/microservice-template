using MongoDB.Bson;
using MongoDB.Driver;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Contracts;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly IMongoDBContext _context;
        protected IMongoCollection<TEntity> _dbSet;
        


        public Repository(IMongoDBContext context)
            : base()
        {
            _context = context;
            _dbSet = context.GetCollection<TEntity>(typeof(TEntity).Name);
            MyFilterDefinition = Builders<TEntity>.Filter.Empty;
        }

        public FilterDefinition<TEntity> MyFilterDefinition { get; set; }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id)));
            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var all = await _dbSet.FindAsync(MyFilterDefinition);
            return all.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string sortBy, ESortDirection sortDirection, int pageIndex, int pageSize)
        {
            return await _dbSet.Find(MyFilterDefinition)
                .Skip(pageIndex * pageSize)
                .Limit(pageSize)
                .Sort(new BsonDocument(sortBy, (int)sortDirection))
                .ToListAsync();
        }


        public async Task<TEntity> Insert(TEntity T) {
            try
            {
                T.CreatedAt = DateTime.Now;
                await Task.Run(() => _dbSet.InsertOne(T));
            }
            catch (Exception)
            {
                throw;
            }

            return T;
        }


        public async void Update(TEntity T, string id)
        {            
            try
            {
                T.UpdatedAt = DateTime.Now;

                await Task.Run(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", new ObjectId(id)), T));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
