using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Models
{
	public class ОтделениеБанка
	{
		[Key]
		public int ID_Отделения { get; set; }
		public string НазваниеОтделения { get; set; }
		public string Адрес { get; set; }
		public string НомерТелефона { get; set; }
        public string? Photo { get; set; }

		[ForeignKey("Сотрудник")]
        public Сотрудник ID_Сотрудника { get; set; }

    }
}
