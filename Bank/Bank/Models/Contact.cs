using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Contact
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Обязательно введите имя")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Обязательно введите фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Обязательно введите почту")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string Email { get; set; }
        [Display(Name = "Введите телефон, который привязан к счету")]
        [Required(ErrorMessage = "Обязательно введите телефон")]
        public string Phone { get; set; }
        [Display(Name = "Введите адрес")]
        [Required(ErrorMessage = "Обязательно введите адрес")]
        public string Address { get; set; }
       
        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Обязательно введите возраст")]
        public int Age { get; set; }
       
        [Display(Name = "Что вы хотите спросить? Напишите :)")]
        [Required(ErrorMessage = "Обязательно введите вопрос")]
        [StringLength(300, ErrorMessage="Превышено количество символов >300")]
        public string Message {  get; set; }

    }
}
