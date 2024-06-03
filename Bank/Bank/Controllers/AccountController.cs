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
            return View("Login"); // Исправлено: возвращаем представление "Login"
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

            return View(модель);
        }
    }
}
