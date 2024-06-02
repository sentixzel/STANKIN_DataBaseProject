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
            var �������������� = _context.���������������.ToList();
            var ��������������ViewModel = ��������������.Select(o => new ��������������
            {
                ID_��������� = o.ID_���������,
                ����������������� = o.�����������������,
                ����� = o.�����,
                ������������� = o.�������������,
               
            }).ToList();

            return View(��������������ViewModel);
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
      

