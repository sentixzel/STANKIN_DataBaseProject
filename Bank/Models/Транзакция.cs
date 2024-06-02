using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class Транзакция
	{
		[Key]
		public int ID_Транзакции { get; set; }
		public int ID_Счета { get; set; }
		public DateTime ДатаТранзакции { get; set; }
		public string ТипТранзакции { get; set; }
		public decimal Сумма { get; set; }
		public string Описание { get; set; }
	}
}
