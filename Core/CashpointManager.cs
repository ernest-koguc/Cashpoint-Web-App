using Core.Exceptions;
using DAL.Entities;

namespace Core
{
    public class CashpointManager : ICashpointManager
    {

        public CashpointManager()
        { }
        public Dictionary<BillsTypes, int> WithdrawMoney(int money, CashpointBalance cashpointBalance, UserAccount userAccount)
        {
            if (money <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(money)} argument cannot be below or equal to zero");
            if (money % 10 != 0)
                throw new NoCoinsInCashpointException();
            if (money > userAccount.Balance)
                throw new InsufficientMoneyInUserBalanceException();
            if (money > cashpointBalance.TotalBalance)
                throw new InsufficientMoneyInCashpointException();

            userAccount.Balance -= money;

            var twoHundreds = money >= 200 ? Math.Min(money / 200, cashpointBalance.TwoHundredBillsCount) : 0;
            money -= twoHundreds * 200;
            cashpointBalance.TwoHundredBillsCount -= twoHundreds;
            var oneHundreds = money >= 100 ? Math.Min(money / 100, cashpointBalance.OneHundredBillsCount) : 0;
            money -= oneHundreds * 100;
            cashpointBalance.OneHundredBillsCount -= oneHundreds;
            var fifties = money >= 50 ? Math.Min(money / 50, cashpointBalance.FiftyBillsCount) : 0;
            money -= fifties * 50;
            cashpointBalance.FiftyBillsCount -= fifties;
            var twenties = money >= 20 ? Math.Min(money / 20, cashpointBalance.TwentyBillsCount) : 0;
            money -= twenties * 20;
            cashpointBalance.TwentyBillsCount -= twenties;
            var tens = money >= 10 ? Math.Min(money / 10, cashpointBalance.TenBillsCount) : 0;
            cashpointBalance.TenBillsCount -= tens;

            var bills = new Dictionary<BillsTypes, int>()
            {
                { BillsTypes.TWO_HUNDRED_PLN_BILL, twoHundreds},
                { BillsTypes.ONE_HUNDRED_PLN_BILL, oneHundreds},
                { BillsTypes.FIFTY_PLN_BILL, fifties},
                { BillsTypes.TWENTY_PLN_BILL, twenties},
                { BillsTypes.TEN_PLN_BILL, tens},
            };

            return bills;
        }
    }
}
