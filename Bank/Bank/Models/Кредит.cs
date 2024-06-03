using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class Кредит
    {
        [Key]
        public int ID_Кредита { get; set; }

        [ForeignKey("Клиент")]
        public int ID_Клиента { get; set; }

        [Required]
        [StringLength(50)]
        public string Тип_кредита { get; set; }

        [Required]
        public decimal Основная_сумма { get; set; }

        [Required]
        public decimal Процентная_ставка { get; set; }

        [Required]
        public DateTime Дата_начала { get; set; }

        public DateTime? Дата_окончания { get; set; }

        public virtual Клиент Клиент { get; set; }
        public virtual ICollection<ПлатежПоКредиту> ПлатежиПоКредитам { get; set; }
    }
}
