using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Contracts;

namespace Infrastructure.Repositories
{
    public class DistribuitorRepository : Repository<Distribuitor>, IDistribuitorRepository
    {
        public DistribuitorRepository(IMongoDBContext contexto)
            : base(contexto)
        {
        }
    }
}
