﻿// <auto-generated />
using System;
using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Models.Клиент", b =>
                {
                    b.Property<int>("ID_Клиента")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Клиента"));

                    b.Property<int>("ID_Отделения")
                        .HasColumnType("int");

                    b.Property<string>("Адрес")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ДатаРождения")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Имя")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Фамилия")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ЭлектроннаяПочта")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Клиента");

                    b.HasIndex("ID_Отделения");

                    b.ToTable("Клиенты");
                });

            modelBuilder.Entity("Bank.Models.Кредит", b =>
                {
                    b.Property<int>("ID_Кредита")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Кредита"));

                    b.Property<int>("ID_Клиента")
                        .HasColumnType("int");

                    b.Property<DateTime>("ДатаНачала")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ДатаОкончания")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ОсновнаяСумма")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ПроцентнаяСтавка")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Статус")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ТипКредита")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Кредита");

                    b.HasIndex("ID_Клиента");

                    b.ToTable("Кредиты");
                });

            modelBuilder.Entity("Bank.Models.ОтделениеБанка", b =>
                {
                    b.Property<int>("ID_Отделения")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Отделения"));

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Адрес")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НазваниеОтделения")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НомерТелефона")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Отделения");

                    b.ToTable("ОтделенияБанков");
                });

            modelBuilder.Entity("Bank.Models.ПлатежПоКредиту", b =>
                {
                    b.Property<int>("ID_Платежа")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Платежа"));

                    b.Property<int>("ID_Кредита")
                        .HasColumnType("int");

                    b.Property<DateTime>("ДатаПлатежа")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("СуммаПлатежа")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Платежа");

                    b.HasIndex("ID_Кредита");

                    b.ToTable("ПлатежиПоКредитам");
                });

            modelBuilder.Entity("Bank.Models.Сотрудник", b =>
                {
                    b.Property<int>("ID_Сотрудника")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Сотрудника"));

                    b.Property<int>("ID_Отделения")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ДатаНаима")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Должность")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Имя")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("НомерТелефона")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ОтделениеID_Отделения")
                        .HasColumnType("int");

                    b.Property<string>("Фамилия")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ЭлектроннаяПочта")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Сотрудника");

                    b.HasIndex("ОтделениеID_Отделения");

                    b.ToTable("Сотрудники");
                });

            modelBuilder.Entity("Bank.Models.Счет", b =>
                {
                    b.Property<int>("ID_Счета")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Счета"));

                    b.Property<int>("ID_Клиента")
                        .HasColumnType("int");

                    b.Property<decimal>("Баланс")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ДатаСоздания")
                        .HasColumnType("datetime2");

                    b.Property<string>("ТипСчета")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Счета");

                    b.HasIndex("ID_Клиента");

                    b.ToTable("Счета");
                });

            modelBuilder.Entity("Bank.Models.Транзакция", b =>
                {
                    b.Property<int>("ID_Транзакции")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Транзакции"));

                    b.Property<int>("ID_Счета")
                        .HasColumnType("int");

                    b.Property<DateTime>("ДатаТранзакции")
                        .HasColumnType("datetime2");

                    b.Property<string>("Описание")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Сумма")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ТипТранзакции")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Транзакции");

                    b.HasIndex("ID_Счета");

                    b.ToTable("Транзакции");
                });

            modelBuilder.Entity("Bank.Models.Клиент", b =>
                {
                    b.HasOne("Bank.Models.ОтделениеБанка", "Отделение")
                        .WithMany("Клиенты")
                        .HasForeignKey("ID_Отделения")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Отделение");
                });

            modelBuilder.Entity("Bank.Models.Кредит", b =>
                {
                    b.HasOne("Bank.Models.Клиент", "Клиент")
                        .WithMany("Кредиты")
                        .HasForeignKey("ID_Клиента")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Клиент");
                });

            modelBuilder.Entity("Bank.Models.ПлатежПоКредиту", b =>
                {
                    b.HasOne("Bank.Models.Кредит", "Кредит")
                        .WithMany("Платежи")
                        .HasForeignKey("ID_Кредита")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Кредит");
                });

            modelBuilder.Entity("Bank.Models.Сотрудник", b =>
                {
                    b.HasOne("Bank.Models.ОтделениеБанка", "Отделение")
                        .WithMany()
                        .HasForeignKey("ОтделениеID_Отделения")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Отделение");
                });

            modelBuilder.Entity("Bank.Models.Счет", b =>
                {
                    b.HasOne("Bank.Models.Клиент", "Клиент")
                        .WithMany("Счета")
                        .HasForeignKey("ID_Клиента")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Клиент");
                });

            modelBuilder.Entity("Bank.Models.Транзакция", b =>
                {
                    b.HasOne("Bank.Models.Счет", "Счет")
                        .WithMany("Транзакции")
                        .HasForeignKey("ID_Счета")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Счет");
                });

            modelBuilder.Entity("Bank.Models.Клиент", b =>
                {
                    b.Navigation("Кредиты");

                    b.Navigation("Счета");
                });

            modelBuilder.Entity("Bank.Models.Кредит", b =>
                {
                    b.Navigation("Платежи");
                });

            modelBuilder.Entity("Bank.Models.ОтделениеБанка", b =>
                {
                    b.Navigation("Клиенты");
                });

            modelBuilder.Entity("Bank.Models.Счет", b =>
                {
                    b.Navigation("Транзакции");
                });
#pragma warning restore 612, 618
        }
    }
}
