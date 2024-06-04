using Bank.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankContext _context;
        private readonly IPasswordHasher<Клиент> _passwordHasher;

        public AccountController(BankContext context, IPasswordHasher<Клиент> passwordHasher)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var клиент = _context.Клиенты
                .FirstOrDefault(k => k.ЭлектроннаяПочта == email);

            if (клиент != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(клиент, клиент.Пароль, password);

                if (result == PasswordVerificationResult.Success)
                {
                    // Авторизация успешна, перенаправляем в личный кабинет
                    return RedirectToAction("Profile", new { id = клиент.ID_Клиента });
                }
            }

            // Авторизация неуспешна, обратно на страницу входа с ошибкой
            ModelState.AddModelError("", "Неверная электронная почта или пароль.");
            return View("Login");
        }

        public IActionResult Profile(int id)
        {
            var клиент = _context.Клиенты.FirstOrDefault(k => k.ID_Клиента == id);
            var счета = _context.Счета.Where(s => s.ID_Клиента == id).ToList();
            var кредиты = _context.Кредиты.Where(c => c.ID_Клиента == id).ToList();

            var модель = new ЛичныйКабинетМодель
            {
                Клиент = клиент,
                Счета = счета,
                Кредиты = кредиты

            };
            if (клиент.ID_Отделения == 1)
            {
                модель.otdel = "Ботаническая улица 41к7";
            }
            else
                if (клиент.ID_Отделения == 2)
            {
                модель.otdel = "Строгинский бульвар 12";
            }
            else
                модель.otdel = "Студенческая улица 33";

            return View(модель);
        }





        // Метод для отображения формы открытия счета
        [HttpGet]
        public IActionResult OpenS(int id)
        {
            // Вывод id для проверки
            Console.WriteLine($"Поступившее ID_Клиента: {id}");

            var model = new OpenAccountViewModel { ID_Клиента = id };
            return View(model);
        }

        // Метод для обработки открытия счета
        [HttpPost]
        public IActionResult OpenAccount(OpenAccountViewModel model)
        {


            if (model.ID_Клиента == null || model.ID_Клиента == 0)
            {
                ModelState.AddModelError("Login", "Не найден ID клиента.");
                return View(model);
            }

            var currentUser = _context.Клиенты.FirstOrDefault(c => c.ID_Клиента == model.ID_Клиента.Value);


            if (currentUser != null)
            {
                var currentAccounts = _context.Счета.Where(a => a.Клиент.ID_Клиента == currentUser.ID_Клиента).ToList();

                if (currentAccounts.Count >= 3)
                {
                    ModelState.AddModelError("OpenAccount", "Вы не можете открыть больше 3 счетов.");
                    return View("OpenAccount", model);
                }

                var account = new Счет
                {
                    Клиент = currentUser,
                    ТипСчета = model.ТипСчета,
                    Баланс = model.НачальныйБаланс,
                    ДатаСоздания = DateTime.Now,
                    НомерСчета = GenerateAccountNumber()

                };

                _context.Счета.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Profile", new { id = currentUser.ID_Клиента });
            }

            ModelState.AddModelError("OpenAccount", "Не удалось найти пользователя.");
            return View("OpenAccount", model);
        }

        // Метод для удаления счета
        [HttpPost]
        public IActionResult DeleteAccount(int accountId, int клиентId)
        {
            var accountToDelete = _context.Счета.FirstOrDefault(a => a.ID_Счета == accountId && a.Клиент.ID_Клиента == клиентId);

            if (accountToDelete != null)
            {
                var otherAccounts = _context.Счета.Where(a => a.Клиент.ID_Клиента == клиентId && a.ID_Счета != accountId).ToList();

                if (otherAccounts.Any())
                {
                    // Переводим баланс на первый из доступных счетов
                    otherAccounts.First().Баланс += accountToDelete.Баланс;

                    _context.Счета.Remove(accountToDelete);
                    _context.SaveChanges();

                    TempData["Message"] = "Счёт успешно удалён, и баланс был переведен на другой счёт.";
                }
                else
                {
                    TempData["Error"] = "Удаление невозможно, так как это единственный счёт клиента.";
                }
            }

            return RedirectToAction("Profile", new { id = клиентId });
        }

        // Метод для генерации номера счета
        private string GenerateAccountNumber()
        {
            var random = new Random();
            return new string(Enumerable.Repeat("0123456789", 20).Select(s => s[random.Next(s.Length)]).ToArray());
        }









    }
}

