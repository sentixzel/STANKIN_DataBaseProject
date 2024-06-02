using System.ComponentModel.DataAnnotations;
namespace Bank.Models
{
	public class Клиент
	{
		[Key]
		public int ID_Клиента { get; set; }
		public string Имя { get; set; }
		public string Фамилия { get; set; }
		public DateTime ДатаРождения { get; set; }
		public string ЭлектроннаяПочта { get; set; }
		public string Адрес { get; set; }
		public int ID_Отделения { get; set; }
	}
}
