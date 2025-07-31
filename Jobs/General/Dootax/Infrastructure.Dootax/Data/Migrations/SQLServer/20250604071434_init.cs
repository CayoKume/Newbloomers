using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Dootax.Data.Migrations.SQLServer
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "general");

            migrationBuilder.CreateTable(
                name: "Dootax_Successful_Log",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    cnpj_emp = table.Column<string>(type: "varchar(14)", nullable: false),
                    documento = table.Column<int>(type: "int", nullable: false),
                    serie = table.Column<string>(type: "varchar(10)", nullable: false),
                    chave_nfe = table.Column<string>(type: "varchar(44)", nullable: false),
                    dt_insert = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dootax_Successful_Log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros_Dootax",
                schema: "general",
                columns: table => new
                {
                    token = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuario = table.Column<string>(type: "varchar(50)", nullable: false),
                    environment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros_Dootax", x => x.token);
                });

            migrationBuilder.InsertData(
                schema: "general",
                table: "Parametros_Dootax",
                columns: new[] { "token", "environment", "usuario" },
                values: new object[,]
                {
                    { new Guid("78391c28-0d30-4d8d-bbcd-735006165ecf"), "homolog", "newbloomers" },
                    { new Guid("87e2c224-fb6a-48c2-82da-8c57584b3169"), "prod", "newbloomers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dootax_Successful_Log",
                schema: "general");

            migrationBuilder.DropTable(
                name: "Parametros_Dootax",
                schema: "general");
        }
    }
}
