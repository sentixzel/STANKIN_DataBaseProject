using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
	public class BankContext : DbContext
	{
		public BankContext(DbContextOptions<BankContext> options) : base(options)
		{
		}

		

		public DbSet<Клиент> Клиенты { get; set; }
		public DbSet<Счет> Счета { get; set; }
		public DbSet<Транзакция> Транзакции { get; set; }
		public DbSet<Кредит> Кредиты { get; set; }
		public DbSet<ПлатежПоКредиту> ПлатежиПоКредитам { get; set; }
		public DbSet<ОтделениеБанка> ОтделенияБанков { get; set; }
		public DbSet<Сотрудник> Сотрудники { get; set; }
	}
}
