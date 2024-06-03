using System;
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
                name: "Сотрудники",
                columns: table => new
                {
                    ID_Сотрудника = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Должность = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Электронная_почта = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Номер_телефона = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Дата_найма = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.ID_Сотрудника);
                });

            migrationBuilder.CreateTable(
                name: "ОтделенияБанков",
                columns: table => new
                {
                    ID_Отделения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    НазваниеОтделения = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Номертелефона = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ID_Сотрудника = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ОтделенияБанков", x => x.ID_Отделения);
                    table.ForeignKey(
                        name: "FK_ОтделенияБанков_Сотрудники_ID_Сотрудника",
                        column: x => x.ID_Сотрудника,
                        principalTable: "Сотрудники",
                        principalColumn: "ID_Сотрудника",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Клиенты",
                columns: table => new
                {
                    ID_Клиента = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ДатаРождения = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ЭлектроннаяПочта = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ID_Отделения = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Клиенты", x => x.ID_Клиента);
                    table.ForeignKey(
                        name: "FK_Клиенты_ОтделенияБанков_ID_Отделения",
                        column: x => x.ID_Отделения,
                        principalTable: "ОтделенияБанков",
                        principalColumn: "ID_Отделения",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Кредиты",
                columns: table => new
                {
                    ID_Кредита = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Клиента = table.Column<int>(type: "int", nullable: false),
                    Тип_кредита = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Основная_сумма = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Процентная_ставка = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Дата_начала = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Дата_окончания = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Кредиты", x => x.ID_Кредита);
                    table.ForeignKey(
                        name: "FK_Кредиты_Клиенты_ID_Клиента",
                        column: x => x.ID_Клиента,
                        principalTable: "Клиенты",
                        principalColumn: "ID_Клиента",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Счета",
                columns: table => new
                {
                    ID_Счета = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Клиента = table.Column<int>(type: "int", nullable: false),
                    Тип_счета = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Баланс = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Дата_создания = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Счета", x => x.ID_Счета);
                    table.ForeignKey(
                        name: "FK_Счета_Клиенты_ID_Клиента",
                        column: x => x.ID_Клиента,
                        principalTable: "Клиенты",
                        principalColumn: "ID_Клиента",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ПлатежиПоКредитам",
                columns: table => new
                {
                    ID_Платежа = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Кредита = table.Column<int>(type: "int", nullable: false),
                    Дата_платежа = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Сумма_платежа = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ПлатежиПоКредитам", x => x.ID_Платежа);
                    table.ForeignKey(
                        name: "FK_ПлатежиПоКредитам_Кредиты_ID_Кредита",
                        column: x => x.ID_Кредита,
                        principalTable: "Кредиты",
                        principalColumn: "ID_Кредита",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Транзакции",
                columns: table => new
                {
                    ID_Транзакции = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Счета = table.Column<int>(type: "int", nullable: false),
                    Дата_транзакции = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Тип_транзакции = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Сумма = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Транзакции", x => x.ID_Транзакции);
                    table.ForeignKey(
                        name: "FK_Транзакции_Счета_ID_Счета",
                        column: x => x.ID_Счета,
                        principalTable: "Счета",
                        principalColumn: "ID_Счета",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Клиенты_ID_Отделения",
                table: "Клиенты",
                column: "ID_Отделения");

            migrationBuilder.CreateIndex(
                name: "IX_Кредиты_ID_Клиента",
                table: "Кредиты",
                column: "ID_Клиента");

            migrationBuilder.CreateIndex(
                name: "IX_ОтделенияБанков_ID_Сотрудника",
                table: "ОтделенияБанков",
                column: "ID_Сотрудника");

            migrationBuilder.CreateIndex(
                name: "IX_ПлатежиПоКредитам_ID_Кредита",
                table: "ПлатежиПоКредитам",
                column: "ID_Кредита");

            migrationBuilder.CreateIndex(
                name: "IX_Счета_ID_Клиента",
                table: "Счета",
                column: "ID_Клиента");

            migrationBuilder.CreateIndex(
                name: "IX_Транзакции_ID_Счета",
                table: "Транзакции",
                column: "ID_Счета");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ПлатежиПоКредитам");

            migrationBuilder.DropTable(
                name: "Транзакции");

            migrationBuilder.DropTable(
                name: "Кредиты");

            migrationBuilder.DropTable(
                name: "Счета");

            migrationBuilder.DropTable(
                name: "Клиенты");

            migrationBuilder.DropTable(
                name: "ОтделенияБанков");

            migrationBuilder.DropTable(
                name: "Сотрудники");
        }
    }
}
