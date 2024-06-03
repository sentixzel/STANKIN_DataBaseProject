using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class Счет
	{
		[Key]
		public int ID_Счета { get; set; }
		public int ID_Клиента { get; set; }
		public string ТипСчета { get; set; }
		public decimal Баланс { get; set; }
		public string ДатаСоздания { get; set; }
	}
}
