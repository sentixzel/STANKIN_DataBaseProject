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
                name: "Клиенты",
                columns: table => new
                {
                    ID_Клиента = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Имя = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Фамилия = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ДатаРождения = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ЭлектроннаяПочта = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    Статус = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ДатаНачала = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ДатаОкончания = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ТипСчета = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Баланс = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ДатаСоздания = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ДатаПлатежа = table.Column<DateTime>(type: "datetime2", nullable: false),
                    СуммаПлатежа = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    ДатаТранзакции = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ТипТранзакции = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Сумма = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Описание = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ОтделенияБанков",
                columns: table => new
                {
                    ID_Отделения = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    НазваниеОтделения = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Адрес = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    НомерТелефона = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Сотрудника = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ОтделенияБанков", x => x.ID_Отделения);
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
                    ДатаНаима = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ОтделениеБанкаID_Отделения = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сотрудники", x => x.ID_Сотрудника);
                    table.ForeignKey(
                        name: "FK_Сотрудники_ОтделенияБанков_ОтделениеБанкаID_Отделения",
                        column: x => x.ОтделениеБанкаID_Отделения,
                        principalTable: "ОтделенияБанков",
                        principalColumn: "ID_Отделения");
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
                name: "IX_Сотрудники_ОтделениеБанкаID_Отделения",
                table: "Сотрудники",
                column: "ОтделениеБанкаID_Отделения");

            migrationBuilder.CreateIndex(
                name: "IX_Счета_ID_Клиента",
                table: "Счета",
                column: "ID_Клиента");

            migrationBuilder.CreateIndex(
                name: "IX_Транзакции_ID_Счета",
                table: "Транзакции",
                column: "ID_Счета");

            migrationBuilder.AddForeignKey(
                name: "FK_Клиенты_ОтделенияБанков_ID_Отделения",
                table: "Клиенты",
                column: "ID_Отделения",
                principalTable: "ОтделенияБанков",
                principalColumn: "ID_Отделения",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ОтделенияБанков_Сотрудники_ID_Сотрудника",
                table: "ОтделенияБанков",
                column: "ID_Сотрудника",
                principalTable: "Сотрудники",
                principalColumn: "ID_Сотрудника",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Сотрудники_ОтделенияБанков_ОтделениеБанкаID_Отделения",
                table: "Сотрудники");

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
