using Models;

namespace Managers.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        Account GetAccountById(int id);
        void AddAccount(Account account);
        Account? UpdateAccount(int id, Account account);
        bool DeleteAccount(int id);
    }
}
