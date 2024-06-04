using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class OpenСreditModel
    {
        public int? ID_Клиента { get; set; }
        public string? ТипКредита { get; set; }
        public decimal СуммаКредита { get; set; }
        public string? Статус { get; set; }
    }
}
