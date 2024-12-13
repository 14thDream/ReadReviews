using Managers.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ReadReviews.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
            return _accountService.GetAccountById(id) switch
            {
                null => NotFound(),
                Account account => Ok(account)
            };
        }

        [HttpPost]
        public ActionResult AddAccount(Account account)
        {
            _accountService.AddAccount(account);
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, Account account)
        {
            return _accountService.UpdateAccount(id, account) switch
            {
                null => NotFound(),
                _ => NoContent()
            };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            return _accountService.DeleteAccount(id) ? NoContent() : NotFound();
        }
    }
}
