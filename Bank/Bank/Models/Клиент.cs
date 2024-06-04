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
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Имя должно содержать только буквы")]
        public string? Имя { get; set; }
        [Required(ErrorMessage = "Фамилия обязательна для ввода")]
        [StringLength(50, ErrorMessage = "Фамилия не должна превышать 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        public string? Фамилия { get; set; }
        [Required(ErrorMessage = "Дата рождения обязательна для ввода")]
        [DataType(DataType.Date, ErrorMessage = "Введите корректную дату")]
        [Display(Name = "Дата рождения")]
        public DateTime ДатаРождения { get; set; }

        [Required]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Номер телефона должен содержать от 10 до 15 цифр и может начинаться с '+'.")]
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "Обязательно введите почту")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string? ЭлектроннаяПочта { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Пароль должен быть не менее 6 символов.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Пароль должен содержать хотя бы одну букву и одну цифру.")]
        public string? Пароль { get; set; }




        [ForeignKey("Отделение")]
        [Required]
        public int ID_Отделения { get; set; }
       // public virtual ОтделениеБанка Отделение { get; set; }
       //
       // public virtual ICollection<Счет> Счета { get; set; }
       // public virtual ICollection<Кредит> Кредиты { get; set; }
    }
}
