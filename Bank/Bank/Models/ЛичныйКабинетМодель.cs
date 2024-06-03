namespace Bank.Models
{
    public class ЛичныйКабинетМодель
    {
        public Клиент Клиент { get; set; }
        public List<Счет> Счета { get; set; }
        public List<Кредит> Кредиты { get; set; }
    }
}
