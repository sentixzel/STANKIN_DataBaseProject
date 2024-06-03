using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bank.Models
{
	public class Клиент
	{
		[Key]
		public int ID_Клиента { get; set; }
        [Required(ErrorMessage = "Имя обязательно для ввода")]
        [StringLength(50, ErrorMessage = "Имя не должно превышать 50 символов")]
        public string Имя { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна для ввода")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        public string Фамилия { get; set; }
        [Required(ErrorMessage = "Дата рождения обязательна для ввода")]
        [DataType(DataType.Date, ErrorMessage = "Введите корректную дату")]
        [Display(Name = "Дата рождения")]
        public string ДатаРождения { get; set; }

        [Required(ErrorMessage = "Обязательно введите почту")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string ЭлектроннаяПочта { get; set; }
        [Required(ErrorMessage = "Пароль обязателен для ввода")]
        [StringLength(100, ErrorMessage = "Пароль не должен превышать 100 символов")]
        public string Пароль { get; set; }

        [ForeignKey("Отделение")]
        public int ID_Отделения { get; set; }
        public virtual ОтделениеБанка Отделение { get; set; }

        public virtual ICollection<Счет> Счета { get; set; }
        public virtual ICollection<Кредит> Кредиты { get; set; }
    }
}
