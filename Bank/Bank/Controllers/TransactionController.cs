using Bank.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BankContext _context;
        private readonly UserManager<Клиент> _userManager;

        public TransactionController(BankContext context, UserManager<Клиент> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int accountId)
        {
            var account = await _context.Счета.FindAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }

            var model = new TransactionViewModel
            {
                AccountId = accountId,
                AccountNumber = account.НомерСчета,
                Balance = account.Баланс
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sourceAccount = await _context.Счета.FirstOrDefaultAsync(a => a.НомерСчета == model.SourceAccountNumber);
            var targetAccount = await _context.Счета.FirstOrDefaultAsync(a => a.НомерСчета == model.TargetAccountNumber);

            if (sourceAccount == null || targetAccount == null)
            {
                ModelState.AddModelError("", "Неверный номер счета.");
                return View(model);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            var clientId = currentUser.ID_Клиента;

            if (sourceAccount.ID_Клиента != clientId && targetAccount.ID_Клиента != clientId)
            {
                ModelState.AddModelError("", "Вы можете только переводить средства между своими счетами или пополнять счета других пользователей.");
                return View(model);
            }

            if (model.TransactionType == "Withdraw" && sourceAccount.ID_Клиента != clientId)
            {
                ModelState.AddModelError("", "Снимать деньги можно только со своих счетов.");
                return View(model);
            }

            if (model.TransactionType == "Withdraw")
            {
                if (sourceAccount.Баланс < model.Amount)
                {
                    ModelState.AddModelError("", "Недостаточно средств на счете.");
                    return View(model);
                }

                sourceAccount.Баланс -= model.Amount;
                targetAccount.Баланс += model.Amount;
            }
            else if (model.TransactionType == "Deposit")
            {
                sourceAccount.Баланс -= model.Amount;
                targetAccount.Баланс += model.Amount;
            }

            _context.Update(sourceAccount);
            _context.Update(targetAccount);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Account");
        }
    }
}
