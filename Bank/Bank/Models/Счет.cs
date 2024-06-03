using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Счет
    {
        [Key]
        public int ID_Счета { get; set; }

        [ForeignKey("Клиент")]
        public int ID_Клиента { get; set; }

        [Required]
        [StringLength(50)]
        public string Тип_счета { get; set; }

        [Required]
        public decimal Баланс { get; set; }

        [Required]
        public DateTime Дата_создания { get; set; }

        public virtual Клиент Клиент { get; set; }
        public virtual ICollection<Транзакция> Транзакции { get; set; }
    }
}
