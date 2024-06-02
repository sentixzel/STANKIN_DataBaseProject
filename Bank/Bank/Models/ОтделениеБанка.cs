using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class ОтделениеБанка
	{
		[Key]
		public int ID_Отделения { get; set; }
		public string НазваниеОтделения { get; set; }
		public string Адрес { get; set; }
		public string НомерТелефона { get; set; }
		public int ID_Сотрудника { get; set; }
	}
}
