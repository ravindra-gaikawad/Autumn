namespace Autumn.API.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
