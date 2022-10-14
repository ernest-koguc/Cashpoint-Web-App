using Core;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CashpointWeb.Services
{
    public interface IWithdrawingService
    {
        int? GetUserBalance();
        Dictionary<BillsTypes, int>? WithdrawMoney(int money, ViewDataDictionary viewData);
    }
}