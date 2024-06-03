using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
	public class ПлатежПоКредиту
	{
		[Key]
		public int ID_Платежа { get; set; }
		public int ID_Кредита { get; set; }
		public string ДатаПлатежа { get; set; }
		public decimal СуммаПлатежа { get; set; }
	}
}
