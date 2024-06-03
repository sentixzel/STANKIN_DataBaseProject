using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class Сотрудник
	{
		[Key]
		public int ID_Сотрудника { get; set; }
		public string Имя { get; set; }
		public string Фамилия { get; set; }
		public string Должность { get; set; }
		public string ЭлектроннаяПочта { get; set; }
		public string НомерТелефона { get; set; }
		public string ДатаНаима { get; set; }
	}
}
