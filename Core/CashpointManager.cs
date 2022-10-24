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


            var bills = IterateBills(money, cashpointBalance);

            cashpointBalance.TwoHundredBillsCount -= bills[BillsTypes.TWO_HUNDRED_PLN_BILL];
            cashpointBalance.OneHundredBillsCount -= bills[BillsTypes.ONE_HUNDRED_PLN_BILL];
            cashpointBalance.FiftyBillsCount -= bills[BillsTypes.FIFTY_PLN_BILL];
            cashpointBalance.TwentyBillsCount -= bills[BillsTypes.TWENTY_PLN_BILL];
            cashpointBalance.TenBillsCount -= bills[BillsTypes.TEN_PLN_BILL];

            userAccount.Balance -= money;


            return bills;
        }

        private Dictionary<BillsTypes, int> IterateBills(int money, CashpointBalance cashpointBalance, int state = 0)
        {
            var moneyWithdrawn = money;
            var twoHundreds = 0;
            var oneHundreds = 0;
            var fifties = 0;
            var twenties = 0;
            var tens = 0;

            if (state <= 0)
            {
                twoHundreds = moneyWithdrawn >= 200 ? Math.Min(moneyWithdrawn / 200, cashpointBalance.TwoHundredBillsCount) : 0;
                moneyWithdrawn -= twoHundreds * 200;
            }

            if (state <= 1)
            {
                oneHundreds = moneyWithdrawn >= 100 ? Math.Min(moneyWithdrawn / 100, cashpointBalance.OneHundredBillsCount) : 0;
                moneyWithdrawn -= oneHundreds * 100;
            }


            if (state <= 2)
            {
                fifties = moneyWithdrawn >= 50 ? Math.Min(moneyWithdrawn / 50, cashpointBalance.FiftyBillsCount) : 0;
                moneyWithdrawn -= fifties * 50;
            }


            if (state <= 3)
            {
                twenties = moneyWithdrawn >= 20 ? Math.Min(moneyWithdrawn / 20, cashpointBalance.TwentyBillsCount) : 0;
                moneyWithdrawn -= twenties * 20;
            }

            if (state <= 4)
            {
                tens = moneyWithdrawn >= 10 ? Math.Min(moneyWithdrawn / 10, cashpointBalance.TenBillsCount) : 0;
                moneyWithdrawn -= tens * 10;
            }

            if (moneyWithdrawn == 0)
            {
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
            if (state == 4)
            {
                throw new InsufficientMoneyInCashpointException();
            }
            else
            {
                state++;
                return IterateBills(money, cashpointBalance, state);
            }
        }
    }
}
