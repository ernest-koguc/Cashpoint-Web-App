using DAL.Entities;

namespace Core
{
    public interface ICashpointManager
    {
        Dictionary<BillsTypes, int> WithdrawMoney(int money, CashpointBalance cashpointBalance, UserAccount userAccount);
    }
}