using Bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class ClientController : Controller
    {
        private readonly BankContext _context;

        public ClientController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
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
                var клиент = new Клиент
                {
                    Имя = model.Имя,
                    Фамилия = model.Фамилия,
                    ДатаРождения = model.ДатаРождения,
                    ЭлектроннаяПочта = model.ЭлектроннаяПочта,
                    Адрес = model.Адрес,
                    ID_Отделения = model.ID_Отделения
                };

                _context.Клиенты.Add(клиент);
                _context.SaveChanges();

                return RedirectToAction("EndRegister", "Client");
            }

            return View();
        }


        public IActionResult EndRegister()
        {
            return View();
        }



    }



}
