﻿using Bank.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
namespace Bank.Controllers
{

    public class TransactionController : Controller
    {
        public IActionResult Index4()
        {
            return View();

        }
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Index1()
        {
            return View();

        }
        public IActionResult Index2()
        {
            return View();

        }
        public IActionResult Index3()
        {
            return View();

        }
        private readonly BankContext _context;

        public TransactionController(BankContext context)
        {
            _context = context;
        }

        public IActionResult Create(int? accountId)
        {

            
            if (accountId == null)
            {
                return BadRequest("ID счета обязателен.");
            }

            var account = _context.Счета.Find(accountId);
            if (account == null)
            {
                return NotFound("Счет не найден.");
            }

            var clientAccounts = _context.Счета.Where(a => a.ID_Клиента == account.ID_Клиента).ToList();

            var viewModel = new TransactionViewModel
            {
                SourceAccountId = account.ID_Счета,
                ClientAccounts = new SelectList(clientAccounts, "ID_Счета", "НомерСчета")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //return RedirectToAction("Index", "Account", new { id = model.SourceAccountId });
                var sourceAccount = _context.Счета.FirstOrDefault(a => a.ID_Счета == model.SourceAccountId);
                var destinationAccount = _context.Счета.FirstOrDefault(a => a.ID_Счета == model.DestinationAccountId);

                if (model.SourceAccountId == model.DestinationAccountId)
                {
                    return RedirectToAction("Index3");

                }

                if (model.Amount <= 0)
                {
                    return RedirectToAction("Index1");
                }
                if ( model.Amount> destinationAccount.Баланс && model.TransactionType == "Deposit")
                {
                    return RedirectToAction("Index2");
                    
                }
                if (sourceAccount == null || destinationAccount == null)
                {
                    return NotFound("Счет не найден.");
                }

                if (sourceAccount.Баланс < model.Amount && model.TransactionType == "Withdraw")
                {
                    return RedirectToAction("Index");
                    ModelState.AddModelError("", "Недостаточно средств на счете для выполнения транзакции.");
                    // Повторно заполняем ClientAccounts
                    model.ClientAccounts = new SelectList(_context.Счета.Where(a => a.ID_Клиента == sourceAccount.ID_Клиента).ToList(), "ID_Счета", "НомерСчета");
                    return View(model);
                }

                if (model.TransactionType == "Withdraw")
                {
                    sourceAccount.Баланс -= model.Amount;
                    destinationAccount.Баланс += model.Amount;
                }
                else if (model.TransactionType == "Deposit")
                {
                    sourceAccount.Баланс += model.Amount;
                    destinationAccount.Баланс -= model.Amount;
                }

                var transaction = new Транзакция
                {
                    ID_Счета = model.SourceAccountId,
                    ДатаТранзакции = DateTime.Now,
                    ТипТранзакции = model.TransactionType,
                    Сумма = model.Amount,
                    Описание = model.Description
                };

                _context.Транзакции.Add(transaction);
                await _context.SaveChangesAsync();

                return RedirectToAction("Profile", "Account", new { id = sourceAccount.ID_Клиента });
            }
            return RedirectToAction("Index", "Home");
            //Console.WriteLine("ModelState.IsValid         000000000000000000000000000000000000000000000000000000000000000\n");
            // Повторно заполняем ClientAccounts
            var clientAccounts = _context.Счета.Where(a => a.ID_Клиента == model.SourceAccountId).ToList();
            model.ClientAccounts = new SelectList(clientAccounts, "ID_Счета", "НомерСчета");

            return View(model);
        }
        
    }
}
