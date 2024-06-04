using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
   
        public class TransactionViewModel
        {
            public int SourceAccountId { get; set; }

            [Required]
            [Display(Name = "Счет назначения")]
            public int DestinationAccountId { get; set; }

            [Required]
            [Range(0.01, double.MaxValue, ErrorMessage = "Введите сумму больше нуля")]
        public decimal Amount { get; set; }

            [Required]
            [Display(Name = "Тип транзакции")]
            public string TransactionType { get; set; } // "Withdraw" или "Deposit"

            [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
            public string? Description { get; set; }

            public SelectList ClientAccounts { get; set; }
        }
    
}
