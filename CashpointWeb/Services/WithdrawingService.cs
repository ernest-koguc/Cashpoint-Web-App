using CashpointWeb.Exceptions;
using Core;
using Core.Exceptions;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Data.SqlTypes;

namespace CashpointWeb.Services
{
    public class WithdrawingService : IWithdrawingService
    {
        private readonly ICashpointManager _cashpointManager;
        private readonly IUnitOfWork _unitOfWork;

        public WithdrawingService(ICashpointManager cashpointManager, IUnitOfWork unitOfWork)
        {
            _cashpointManager = cashpointManager;
            _unitOfWork= unitOfWork;
        }

        public int? GetUserBalance()
        {
            var userAccount = _unitOfWork.AccountRepository.GetAll().FirstOrDefault();
            if (userAccount is null)
                return null;

            return userAccount.Balance;
        }

        public Dictionary<BillsTypes, int>? WithdrawMoney(int money, ViewDataDictionary viewData)
        {
            try
            {

                var user = _unitOfWork.AccountRepository.GetAll().FirstOrDefault();
                var cashpointBalance = _unitOfWork.BalanceRepository.GetAll().FirstOrDefault();

                if (user is null || cashpointBalance is null)
                    throw new EmptySqlDatabaseException("SQL Database is empty");

                var bills = _cashpointManager.WithdrawMoney(money, cashpointBalance, user);
                _unitOfWork.SaveChanges();
                return bills;
            }
            catch (Exception ex)
            {
                if (ex is EmptySqlDatabaseException)
                    viewData["ErrorMessage"] = "SQL Database is empty";

                if (ex is InsufficientMoneyInCashpointException)
                    viewData["ErrorMessage"] = "There isn't sufficient amount of money in cashpoint";

                if (ex is InsufficientMoneyInUserBalanceException)
                    viewData["ErrorMessage"] = "There isn't sufficient amount of money in user balance";

                if (ex is NoCoinsInCashpointException)
                    viewData["ErrorMessage"] = "You can only withdraw money in bills";
            }
            return null;
        }
    }
}
