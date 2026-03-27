using Day64MiniProject.Models;

namespace Day64MiniProject.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(Account account);

        Task<List<Account>> GetAllAccounts();

        Task<Account?> GetAccountById(int id);

        Task Deposit(int accountId, decimal amount);

        Task Withdraw(int accountId, decimal amount);
    }
}