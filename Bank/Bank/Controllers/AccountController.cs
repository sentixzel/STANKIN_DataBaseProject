using Bank.Models;
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

        public AccountController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var клиент = _context.Клиенты
                .FirstOrDefault(k => k.ЭлектроннаяПочта == email && k.Пароль == password);

            if (клиент != null)
            {
                // Авторизация успешна, перенаправляем в личный кабинет
                return RedirectToAction("Profile", new { id = клиент.ID_Клиента });
            }

            // Авторизация неуспешна, обратно на страницу входа с ошибкой
            ModelState.AddModelError("", "Неверная электронная почта или адрес.");
            return View();
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
