using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class Кредит
	{
		[Key]
		public int ID_Кредита { get; set; }
		public int ID_Клиента { get; set; }
		public string? ТипКредита { get; set; }
		public decimal ОсновнаяСумма { get; set; }
		public decimal ПроцентнаяСтавка { get; set; }
		public string ДатаНачала { get; set; }
		public string ДатаОкончания { get; set; }
        public string? Статус { get; set; }
    }
}
