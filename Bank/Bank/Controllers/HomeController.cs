using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank;
namespace Bank.Controllers
{


    public class HomeController : Controller
    {


        private readonly BankContext _context;

        public HomeController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var отделенияБанка = _context.ОтделенияБанков.ToList();
            var отделенияБанкаViewModel = отделенияБанка.Select(o => new ОтделениеБанка
            {
                ID_Отделения = o.ID_Отделения,
                НазваниеОтделения = o.НазваниеОтделения,
                Адрес = o.Адрес,
                НомерТелефона = o.НомерТелефона,
               
            }).ToList();

            return View(отделенияБанкаViewModel);
        }










       // private readonly ILogger<HomeController> _logger;
       //
       // public HomeController(ILogger<HomeController> logger)
       // {
       //     _logger = logger;
       // }
       //
       // public IActionResult Index()
       // {
       //     
       //
       //     return View();
       // }
       //
    }
}
      

