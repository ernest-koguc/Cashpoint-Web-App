using DAL.Entities;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<CashpointBalance> BalanceRepository { get; init; }
        public IRepository<UserAccount> AccountRepository { get; init; }

        private readonly CashpointDBContext _dbContext;

        public UnitOfWork(IRepository<CashpointBalance> balanceRepository, IRepository<UserAccount> accountRepository, CashpointDBContext cashpointDBContext)
        {
            BalanceRepository = balanceRepository;
            AccountRepository = accountRepository;
            _dbContext = cashpointDBContext;

            if (!BalanceRepository.GetAll().Any() || !AccountRepository.GetAll().Any())
                SeedData();

        }

        private void SeedData()
        {
            _dbContext.Accounts.RemoveRange(_dbContext.Accounts);

            var account = new UserAccount() { Balance = 7654 };
            _dbContext.Accounts.Add(account);
            _dbContext.Balances.RemoveRange(_dbContext.Balances);
            var balance = new CashpointBalance() { TwoHundredBillsCount = 5, OneHundredBillsCount = 5, FiftyBillsCount = 5, TwentyBillsCount = 5, TenBillsCount = 5 };
            _dbContext.Balances.Add(balance);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }
}
