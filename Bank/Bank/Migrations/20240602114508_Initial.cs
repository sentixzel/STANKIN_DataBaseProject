﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Клиенты",
                columns: table => new
                {
                    ID_Клиента = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ДатаРождения = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ЭлектроннаяПочта = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Отделения = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Клиенты", x => x.ID_Клиента);
                });

            migrationBuilder.CreateTable(
                name: "Кредиты",
                columns: table => new
                {
                    ID_Кредита = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Клиента = table.Column<int>(type: "int", nullable: false),
                    ТипКредита = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ОсновнаяСумма = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ПроцентнаяСтавка = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ДатаНачала = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаОкончания = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Кредиты", x => x.ID_Кредита);
                });

            migrationBuilder.CreateTable(
                name: "ОтделенияБанков",
                columns: table => new
                {
                    ID_Отделения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    НазваниеОтделения = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    НомерТелефона = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Сотрудника = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ОтделенияБанков", x => x.ID_Отделения);
                });

            migrationBuilder.CreateTable(
                name: "ПлатежиПоКредитам",
                columns: table => new
                {
                    ID_Платежа = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Кредита = table.Column<int>(type: "int", nullable: false),
                    ДатаПлатежа = table.Column<DateTime>(type: "datetime2", nullable: false),
                    СуммаПлатежа = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ПлатежиПоКредитам", x => x.ID_Платежа);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    ID_Сотрудника = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Должность = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ЭлектроннаяПочта = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    НомерТелефона = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ДатаНаима = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.ID_Сотрудника);
                });

            migrationBuilder.CreateTable(
                name: "Счета",
                columns: table => new
                {
                    ID_Счета = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Клиента = table.Column<int>(type: "int", nullable: false),
                    ТипСчета = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Баланс = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Счета", x => x.ID_Счета);
                });

            migrationBuilder.CreateTable(
                name: "Транзакции",
                columns: table => new
                {
                    ID_Транзакции = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Счета = table.Column<int>(type: "int", nullable: false),
                    ДатаТранзакции = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ТипТранзакции = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Сумма = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Транзакции", x => x.ID_Транзакции);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Клиенты");

            migrationBuilder.DropTable(
                name: "Кредиты");

            migrationBuilder.DropTable(
                name: "ОтделенияБанков");

            migrationBuilder.DropTable(
                name: "ПлатежиПоКредитам");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Счета");

            migrationBuilder.DropTable(
                name: "Транзакции");
        }
    }
}
