using Vertem.Agrega.Infra.Contracts;

namespace Vertem.Agrega.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {

        protected readonly IMongoDBContext _context;

        public UnitOfWork(IMongoDBContext contexto)
        {
            _context = contexto;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChanges() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }


    }
}
