using CashpointWeb.Models;
using CashpointWeb.Models.Validators;
using CashpointWeb.Services;
using Core;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using FluentValidation;

namespace CashpointWeb.IoC
{
    public static class IoCRegisterer
    {
        public static void RegisterPagesServices(this IServiceCollection services)
        {
            services.AddScoped<IWithdrawingService, WithdrawingService>();
        }
        public static void RegisterCore(this IServiceCollection services)
        {
            services.AddScoped<ICashpointManager, CashpointManager>();
        }
        public static void RegisterDAL(this IServiceCollection services)
        {
            services.AddScoped<IRepository<CashpointBalance>, Repository<CashpointBalance>>();
            services.AddScoped<IRepository<UserAccount>, Repository<UserAccount>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CashpointDBContext>();
        }
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<MoneyWithdraw>, MoneyWithdrawValidator>();
        }
    }
}
