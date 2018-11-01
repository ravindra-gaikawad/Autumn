namespace Autumn.API.UoW
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IDbContextTransaction dbContextTransaction;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        void IUnitOfWork.BeginTransaction()
        {
            this.dbContextTransaction = this.context.Database.BeginTransaction();
        }

        void IUnitOfWork.CommitTransaction()
        {
            if (this.dbContextTransaction == null)
            {
                return;
            }

            this.context.SaveChanges();
            this.dbContextTransaction.Commit();

            this.dbContextTransaction = null;
        }

        void IUnitOfWork.RollbackTransaction()
        {
            if (this.dbContextTransaction == null)
            {
                return;
            }

            this.dbContextTransaction.Rollback();

            this.dbContextTransaction = null;
        }
    }
}
