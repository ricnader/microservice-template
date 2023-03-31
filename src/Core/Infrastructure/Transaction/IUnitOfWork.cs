namespace Vertem.Agrega.Infra.Transaction
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
