using Managers.Context;
using Managers.Services;
using Models;

namespace Managers
{
    public class AccountManager : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccounts() => _context.Accounts.ToList();
        public Account? GetAccountById(int id) => _context.Accounts.Find(id);

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Account? UpdateAccount(int id, Account account)
        {
            var existingAccount = GetAccountById(id);
            if (existingAccount == null)
            {
                return null;
            }

            existingAccount = account;
            _context.SaveChanges();

            return existingAccount;
        }

        public bool DeleteAccount(int id)
        {
            var account = GetAccountById(id);
            if (account == null)
            {
                return false;
            }

            _context.Accounts.Remove(account);
            _context.SaveChanges();

            return true;
        }
    }
}
