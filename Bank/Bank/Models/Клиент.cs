using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bank.Models
{
    public class Клиент
    {
        [Key]
        public int ID_Клиента { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        public DateTime ДатаРождения { get; set; }

        [Required]
        [EmailAddress]
        public string ЭлектроннаяПочта { get; set; }

        [Required]
        [StringLength(100)]
        public string Адрес { get; set; }

        [ForeignKey("ОтделениеБанка")]
        public int ID_Отделения { get; set; }

        public virtual ОтделениеБанка ОтделениеБанка { get; set; }
        public virtual ICollection<Счет> Счета { get; set; }
        public virtual ICollection<Кредит> Кредиты { get; set; }
    }
}
