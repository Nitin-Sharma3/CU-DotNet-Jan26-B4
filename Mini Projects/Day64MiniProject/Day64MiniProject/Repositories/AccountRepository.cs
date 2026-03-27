using Day64MiniProject.Data;
using Day64MiniProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Day64MiniProject.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Account.ToListAsync();
        }

        public async Task<Account?> GetAccountById(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task UpdateAccount(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}