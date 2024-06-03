using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Сотрудник
    {
        [Key]
        public int ID_Сотрудника { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(50)]
        public string Должность { get; set; }

        [Required]
        [EmailAddress]
        public string Электронная_почта { get; set; }

        [Required]
        [StringLength(20)]
        public string Номер_телефона { get; set; }

        [Required]
        public DateTime Дата_найма { get; set; }

        public virtual ICollection<ОтделениеБанка> Отделения { get; set; }
    }
}
