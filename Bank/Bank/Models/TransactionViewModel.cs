using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class TransactionViewModel
    {
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Номер счета источника")]
        public string SourceAccountNumber { get; set; }

        [Required]
        [Display(Name = "Номер счета получателя")]
        public string TargetAccountNumber { get; set; }

        [Required]
        [Range(0, 100000, ErrorMessage = "Введите валидную сумму")]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Тип транзакции")]
        public string TransactionType { get; set; }

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
