using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
    public class ОтделениеБанка
    {
        [Key]
        public int ID_Отделения { get; set; }

        [Required]
        [StringLength(100)]
        public string НазваниеОтделения { get; set; }

        [Required]
        [StringLength(100)]
        public string Адрес { get; set; }
        public string? Photo { get; set; }
        [Required]
        [StringLength(20)]
        public string Номертелефона { get; set; }

        [ForeignKey("Сотрудник")]
        public int ID_Сотрудника { get; set; }

        public virtual Сотрудник Сотрудник { get; set; }
        public virtual ICollection<Клиент> Клиенты { get; set; }
    }
}
