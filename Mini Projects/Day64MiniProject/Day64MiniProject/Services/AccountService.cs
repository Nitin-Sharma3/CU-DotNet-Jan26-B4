using Day64MiniProject.Models;
using Day64MiniProject.Repositories;
using Day64MiniProject.Helper;
namespace Day64MiniProject.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = null;
        public AccountService(IAccountRepository repo)
        {
            _accountRepository = repo;
        }
        public async Task<Account> CreateAccount(Account account)
        {
            if (account.Balance < 1000)
            {
                throw new Exception("Minimum deposit must be 1000");
            }

            var acc =  await _accountRepository.CreateAccount(account);
            acc.AccountNumber = AccountNumberGenerator.GenerateAccNo(acc.Id);
            await _accountRepository.UpdateAccount(acc);
            return acc;
        }

        public async Task Deposit(int accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than 0");
            }
            var accbal = await _accountRepository.GetAccountById(accountId);
            accbal.Balance += amount;
            await _accountRepository.UpdateAccount(accbal);
        }

        public async Task<Account?> GetAccountById(int id)
        {
            var acc = await _accountRepository.GetAccountById(id);
            return acc;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            List<Account> accounts = await _accountRepository.GetAllAccounts();
            return accounts;
        }

        public async Task Withdraw(int accountId, decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount must be greater than 0");
            }
            var accid = await _accountRepository.GetAccountById(accountId);
            if (accid.Balance - amount < 1000) { throw new Exception("Balance no enough"); }
            accid.Balance -= amount;
            await _accountRepository.UpdateAccount(accid);
        }
    }
}
