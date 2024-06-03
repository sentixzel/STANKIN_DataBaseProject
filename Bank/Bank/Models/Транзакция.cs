using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Транзакция
    {
        [Key]
        public int ID_Транзакции { get; set; }

        [ForeignKey("Счет")]
        public int ID_Счета { get; set; }

        [Required]
        public DateTime Дата_транзакции { get; set; }

        [Required]
        [StringLength(50)]
        public string Тип_транзакции { get; set; }

        [Required]
        public decimal Сумма { get; set; }

        [StringLength(200)]
        public string Описание { get; set; }

        public virtual Счет Счет { get; set; }
    }
}
