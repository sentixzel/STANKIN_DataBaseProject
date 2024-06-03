using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class ПлатежПоКредиту
    {
        [Key]
        public int ID_Платежа { get; set; }

        [ForeignKey("Кредит")]
        public int ID_Кредита { get; set; }

        [Required]
        public DateTime Дата_платежа { get; set; }

        [Required]
        public decimal Сумма_платежа { get; set; }

        public virtual Кредит Кредит { get; set; }
    }
}
