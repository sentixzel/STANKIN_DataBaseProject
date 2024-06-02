﻿using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
	public class BankContext : DbContext
	{
		public BankContext(DbContextOptions<BankContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=BankBD;User ID=dlyaconnecta;Password=lalalalalalala7;")
					.LogTo(Console.WriteLine, LogLevel.Information);
			}
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
