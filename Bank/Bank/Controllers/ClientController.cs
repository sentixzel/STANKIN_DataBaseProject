using Bank.Models;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
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
            var model = new ViewVerify
            {
                ID_Отделения = branchId
            };

            return View(model);
        }


        int kod;

        [HttpPost]
        public IActionResult Register(ViewVerify model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var existingClient = _context.Клиенты
           .FirstOrDefault(c => c.ЭлектроннаяПочта == model.ЭлектроннаяПочта || c.PhoneNumber == model.PhoneNumber);

                    if (existingClient != null)
                    {
                        // Определяем, что уже занято: электронная почта или телефон
                        if (existingClient.ЭлектроннаяПочта == model.ЭлектроннаяПочта)
                        {
                            ModelState.AddModelError("ЭлектроннаяПочта", "Электронная почта уже используется.");
                        }
                        if (existingClient.PhoneNumber == model.PhoneNumber)
                        {
                            ModelState.AddModelError("PhoneNumber", "Номер телефона уже используется.");
                        }
                        return View(model);
                    }


                    if (existingClient != null)
                    {
                        ModelState.AddModelError("ЭлектроннаяПочта", "Электронная почта уже используется.");
                        return View(model);
                    }



                    //PHONE
                    var existingClient1 = _context.Клиенты
                     .FirstOrDefault(c => c.PhoneNumber == model.PhoneNumber);
                    if (existingClient != null)
                    {
                        ModelState.AddModelError("PhoneNumber", "Телефон уже был зарегистрирован");
                        return View(model);
                    }


                    // Генерация кода подтверждения и отправка письма
                    string smtpServer = "smtp.mail.ru";
                    int smtpPort = 587;
                    string smtpUsername = "arina_andrey2004@mail.ru";
                    string smtpPassword = "WdR03VPBFFgBeBG66HPu";

                    Random random = new Random();
                    kod = random.Next(1000, 10000);

                    using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true;
                        using (MailMessage mailMessage = new MailMessage())
                        {
                            mailMessage.From = new MailAddress(smtpUsername);
                            mailMessage.To.Add(model.ЭлектроннаяПочта);
                            mailMessage.Subject = "Обратная связь";
                            mailMessage.Body = $"Здравствуйте {model.Имя}, ваш код подтверждения {kod}";
                            smtpClient.Send(mailMessage);
                        }
                    }

                    TempData["ViewVerifyModel"] = JsonConvert.SerializeObject(model);
                    TempData["Kod"] = kod;

                    return RedirectToAction("Verify");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Ошибка при добавлении клиента: {ex.Message}");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Verify()
        {
            if (TempData.TryGetValue("ViewVerifyModel", out object serializedModel) &&
                TempData.TryGetValue("Kod", out object kodFromTempData))
            {
                var model = JsonConvert.DeserializeObject<ViewVerify>(serializedModel as string);
                int kod = (int)kodFromTempData;

                // Сохранение данных TempData для следующего запроса
                TempData.Keep("ViewVerifyModel");
                TempData.Keep("Kod");

                return View(model);
            }

            // Обработка случая, когда TempData не содержит нужных данных.
            return RedirectToAction("ERROR");
        }

        [HttpPost]
        public IActionResult Verify(ViewVerify model)
        {
            if (TempData.TryGetValue("Kod", out object kodFromTempData))
            {
                int kod = (int)kodFromTempData;
                

                if (model.Verify == kod)
                {
                    TempData.TryGetValue("ViewVerifyModel", out object serializedModel);
                   model = JsonConvert.DeserializeObject<ViewVerify>(serializedModel as string);
                    var клиент = new Клиент
                    {
                        Имя = model.Имя,
                        Фамилия = model.Фамилия,
                        ДатаРождения = model.ДатаРождения,
                        ЭлектроннаяПочта = model.ЭлектроннаяПочта,
                        ID_Отделения = model.ID_Отделения,
                        PhoneNumber = model.PhoneNumber

                    };

                    // Хэширование пароля
                    клиент.Пароль = _passwordHasher.HashPassword(клиент, model.Пароль);

                    _context.Клиенты.Add(клиент);
                    _context.SaveChanges();

                    return RedirectToAction("EndRegister", "Client");
                }

                TempData.Keep("ViewVerifyModel");
                TempData.Keep("Kod");
                ModelState.AddModelError("Verify", "Код не верный");
                return View(model);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Недостаточно данных в TempData.");

            }

            return View(model);
        }







        public IActionResult EndRegister()
        {
            return View();
        }







    }

   


       


    }




