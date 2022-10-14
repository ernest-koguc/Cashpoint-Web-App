using CashpointWeb.Extensions;
using CashpointWeb.Models;
using CashpointWeb.Services;
using Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashpointWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IValidator<MoneyWithdraw> _validator;
        private readonly IWithdrawingService _withdrawingService;

        [BindProperty]
        public MoneyWithdraw MoneyWithdraw { get; set; } = new();


        public IndexModel(IWithdrawingService withdrawingService, IValidator<MoneyWithdraw> validator)
        {
            _validator = validator;
            _withdrawingService = withdrawingService;
            ModelState.Clear();
        }

        public void OnGet()
        {
            ViewData["UserBalance"] = _withdrawingService.GetUserBalance();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var result = await _validator.ValidateAsync(MoneyWithdraw);

            if (!result.IsValid)
            {

                result.AddToModelState(this.ModelState);

                return Page();
            }

            var money = MoneyWithdraw.Value;
            var bills = _withdrawingService.WithdrawMoney(money, this.ViewData);

            if (bills is not null)
            {
                ViewData["200"] = $"200 PLN BILLS: {bills[BillsTypes.TWO_HUNDRED_PLN_BILL]}";
                ViewData["100"] = $"100 PLN BILLS: {bills[BillsTypes.ONE_HUNDRED_PLN_BILL]}";
                ViewData["50"] = $"50 PLN BILLS: {bills[BillsTypes.FIFTY_PLN_BILL]}";
                ViewData["20"] = $"20 PLN BILLS: {bills[BillsTypes.TWENTY_PLN_BILL]}";
                ViewData["10"] = $"10 PLN BILLS: {bills[BillsTypes.TEN_PLN_BILL]}";
            }

            ViewData["UserBalance"] = _withdrawingService.GetUserBalance();
            return Page();
        }
    }
}