using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.AfterSale.Data.Migrations.SQLServer
{
    /// <inheritdoc />
    public partial class inituntreated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfterSaleTrackings",
                schema: "untreated",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    reverse_id = table.Column<int>(type: "int", nullable: true),
                    courier_contract_id = table.Column<int>(type: "int", nullable: true),
                    authorization_code = table.Column<string>(type: "varchar(60)", nullable: true),
                    tracking_code = table.Column<string>(type: "varchar(60)", nullable: true),
                    shipping_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    package_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    courier_name = table.Column<string>(type: "varchar(60)", nullable: true),
                    tracking_url = table.Column<string>(type: "varchar(4000)", nullable: true),
                    expire_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    collect_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requested_collect_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", nullable: true),
                    message = table.Column<string>(type: "varchar(60)", nullable: true),
                    status_updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_change_collect_to_post = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<string>(type: "varchar(60)", nullable: true),
                    qr_code = table.Column<string>(type: "varchar(60)", nullable: true),
                    service_type = table.Column<string>(type: "varchar(60)", nullable: true),
                    cte = table.Column<string>(type: "varchar(60)", nullable: true),
                    delivery_deadline = table.Column<string>(type: "varchar(60)", nullable: true),
                    extra_fields = table.Column<string>(type: "varchar(60)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleTrackings", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfterSaleTrackings",
                schema: "untreated");
            
        }
    }
}
