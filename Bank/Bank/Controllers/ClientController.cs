using Bank.Models;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class ClientController : Controller
    {
        private readonly BankContext _context;
        private readonly IPasswordHasher<Клиент> _passwordHasher;

        public ClientController(BankContext context, IPasswordHasher<Клиент> passwordHasher)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public IActionResult Register(int branchId)
        {
            var model = new Клиент
            {
                ID_Отделения = branchId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Клиент model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var клиент = new Клиент
                    {
                        Имя = model.Имя,
                        Фамилия = model.Фамилия,
                        ДатаРождения = model.ДатаРождения,
                        ЭлектроннаяПочта = model.ЭлектроннаяПочта,
                        ID_Отделения = model.ID_Отделения
                    };

                    // Хэшируем пароль
                    клиент.Пароль = _passwordHasher.HashPassword(клиент, model.Пароль);

                    _context.Клиенты.Add(клиент);
                    _context.SaveChanges();

                    return RedirectToAction("EndRegister", "Client");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Ошибка при добавлении клиента: {ex.Message}");
                }
            }

            return View(model);
        }

       
        public IActionResult EndRegister()
        {
            return View();
        }
    }

   


       


    }




