using Day64MiniProject.Models;

namespace Day64MiniProject.Repositories
{
    public interface IAccountRepository
    {
        public  Task<Account> CreateAccount(Account account);
        public  Task<List<Account>> GetAllAccounts();
        public  Task<Account?> GetAccountById(int id);
        public  Task UpdateAccount(Account account);
    }
}
