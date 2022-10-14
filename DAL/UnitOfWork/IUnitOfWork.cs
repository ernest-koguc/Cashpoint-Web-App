using DAL.Entities;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<CashpointBalance> BalanceRepository { get; init; }
        IRepository<UserAccount> AccountRepository { get; init; }
        void SaveChanges();
    }
}