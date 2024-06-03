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

        // GET: ОтделенияБанков
        public async Task<IActionResult> Index()
        {
            var отделенияБанков = await _context.ОтделенияБанков.ToListAsync();
            return View(отделенияБанков);
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult Uslov()
        {
            return View();
        }



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

      

