using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.AfterSale.Data.Migrations.SQLServer
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
                name: "AfterSaleAddresses",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    zip_code = table.Column<string>(type: "char(9)", nullable: true),
                    address = table.Column<string>(type: "varchar(250)", nullable: true),
                    complement = table.Column<string>(type: "varchar(60)", nullable: true),
                    number = table.Column<string>(type: "varchar(20)", nullable: true),
                    neighborhood = table.Column<string>(type: "varchar(60)", nullable: true),
                    city = table.Column<string>(type: "varchar(40)", nullable: true),
                    state = table.Column<string>(type: "varchar(20)", nullable: true),
                    lat = table.Column<string>(type: "varchar(60)", nullable: true),
                    @long = table.Column<string>(name: "long", type: "varchar(60)", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleAddresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleStatus",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(60)", nullable: true),
                    description = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleTransportations",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleTransportations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros_AfterSale",
                schema: "general",
                columns: table => new
                {
                    CNPJ_EMP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TOKEN = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros_AfterSale", x => x.CNPJ_EMP);
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleCustomers",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    contact_email = table.Column<string>(type: "varchar(50)", nullable: true),
                    document = table.Column<string>(type: "varchar(14)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    first_name = table.Column<string>(type: "varchar(60)", nullable: true),
                    last_name = table.Column<string>(type: "varchar(60)", nullable: true),
                    phone = table.Column<string>(type: "varchar(30)", nullable: true),
                    shipping_address_id = table.Column<int>(type: "int", nullable: true),
                    shipping_addressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleCustomers", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleCustomers_AfterSaleAddresses_shipping_address_id",
                        column: x => x.shipping_address_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleAddresses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AfterSaleCustomers_AfterSaleAddresses_shipping_addressid",
                        column: x => x.shipping_addressid,
                        principalSchema: "general",
                        principalTable: "AfterSaleAddresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleEcommerces",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ecommerce_group_id = table.Column<int>(type: "int", nullable: true),
                    company_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    trade_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    display_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    url = table.Column<string>(type: "varchar(4000)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true),
                    phone = table.Column<string>(type: "varchar(30)", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", nullable: true),
                    document = table.Column<string>(type: "varchar(20)", nullable: true),
                    address_id = table.Column<int>(type: "int", nullable: true),
                    maintenance_mode_global = table.Column<bool>(type: "bit", nullable: true),
                    last_order_report_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_test = table.Column<bool>(type: "bit", nullable: true),
                    segment = table.Column<string>(type: "varchar(60)", nullable: true),
                    oauth_client_id = table.Column<string>(type: "varchar(60)", nullable: true),
                    provider_id = table.Column<string>(type: "varchar(60)", nullable: true),
                    registration_origin = table.Column<string>(type: "varchar(60)", nullable: true),
                    brand_id = table.Column<string>(type: "varchar(60)", nullable: true),
                    app_name = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleEcommerces", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleEcommerces_AfterSaleAddresses_address_id",
                        column: x => x.address_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleAddresses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleReasons",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ecommerce_id = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "varchar(60)", nullable: true),
                    reason_category_id = table.Column<string>(type: "varchar(60)", nullable: true),
                    action = table.Column<string>(type: "varchar(60)", nullable: true),
                    should_approve = table.Column<bool>(type: "bit", nullable: true),
                    upload_image = table.Column<string>(type: "varchar(60)", nullable: true),
                    show_product_grid = table.Column<bool>(type: "bit", nullable: true),
                    ord = table.Column<string>(type: "varchar(60)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleReasons", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleReasons_AfterSaleEcommerces_ecommerce_id",
                        column: x => x.ecommerce_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleEcommerces",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleReverses",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    reverse_type = table.Column<string>(type: "varchar(50)", nullable: true),
                    courier_collect = table.Column<bool>(type: "bit", nullable: true),
                    courier_service_type = table.Column<string>(type: "varchar(50)", nullable: true),
                    service_type_changed = table.Column<string>(type: "varchar(50)", nullable: true),
                    ecommerce_order_id = table.Column<int>(type: "int", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: true),
                    courier_contract_id = table.Column<int>(type: "int", nullable: true),
                    brand_id = table.Column<int>(type: "int", nullable: true),
                    total_amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    invoice = table.Column<int>(type: "int", nullable: true),
                    posting_card = table.Column<string>(type: "varchar(50)", nullable: true),
                    is_store_seller_contract = table.Column<bool>(type: "bit", nullable: true),
                    locker_reference = table.Column<string>(type: "varchar(50)", nullable: true),
                    store_expire_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    skip_process_step = table.Column<bool>(type: "bit", nullable: true),
                    freight_by_customer = table.Column<bool>(type: "bit", nullable: true),
                    tracking_error = table.Column<string>(type: "varchar(50)", nullable: true),
                    origin = table.Column<string>(type: "varchar(50)", nullable: true),
                    external_source = table.Column<string>(type: "varchar(50)", nullable: true),
                    order_sequence_number = table.Column<string>(type: "varchar(50)", nullable: true),
                    billing_item_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "varchar(50)", nullable: true),
                    ecommerce_id = table.Column<int>(type: "int", nullable: true),
                    partner_store = table.Column<string>(type: "varchar(50)", nullable: true),
                    destination_seller_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    origin_seller_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    is_erased = table.Column<bool>(type: "bit", nullable: true),
                    service_type_change = table.Column<int>(type: "int", nullable: true),
                    billing_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    must_treat_refund = table.Column<bool>(type: "bit", nullable: true),
                    reverse_type_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    is_generic_courier = table.Column<bool>(type: "bit", nullable: true),
                    can_generate_voucher = table.Column<bool>(type: "bit", nullable: true),
                    could_cancel = table.Column<bool>(type: "bit", nullable: true),
                    can_send_correction_letter = table.Column<bool>(type: "bit", nullable: true),
                    correction_letter_link = table.Column<string>(type: "varchar(4000)", nullable: true),
                    customer_url = table.Column<string>(type: "varchar(4000)", nullable: true),
                    timeline_url = table.Column<string>(type: "varchar(4000)", nullable: true),
                    collect_scheduling_link = table.Column<string>(type: "varchar(4000)", nullable: true),
                    returned_invoice = table.Column<string>(type: "varchar(50)", nullable: true),
                    dot_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    order_id = table.Column<string>(type: "varchar(50)", nullable: true),
                    refunds_count = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleReverses", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleReverses_AfterSaleCustomers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleCustomers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AfterSaleReverses_AfterSaleEcommerces_ecommerce_id",
                        column: x => x.ecommerce_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleEcommerces",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AfterSaleReverses_AfterSaleStatus_status_id",
                        column: x => x.status_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleStatus",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleStatusHistories",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    reverse_id = table.Column<int>(type: "int", nullable: true),
                    status_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    comments = table.Column<string>(type: "varchar(60)", nullable: true),
                    statusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleStatusHistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleStatusHistories_AfterSaleReverses_reverse_id",
                        column: x => x.reverse_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleReverses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_AfterSaleStatusHistories_AfterSaleStatus_statusid",
                        column: x => x.statusid,
                        principalSchema: "general",
                        principalTable: "AfterSaleStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AfterSaleTrackingHistories",
                schema: "general",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    tracking_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(60)", nullable: true),
                    message = table.Column<string>(type: "varchar(3000)", nullable: true),
                    status_updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfterSaleTrackingHistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_AfterSaleTrackingHistories_AfterSaleReverses_tracking_id",
                        column: x => x.tracking_id,
                        principalSchema: "general",
                        principalTable: "AfterSaleReverses",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "general",
                table: "Parametros_AfterSale",
                columns: new[] { "CNPJ_EMP", "TOKEN" },
                values: new object[,]
                {
                    { "38367316000199", new Guid("69ea80a0-0472-11ee-993e-37eecaae1115") },
                    { "42538267000268", new Guid("56dfd210-0472-11ee-bfa0-99577f33d6f0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleCustomers_shipping_address_id",
                schema: "general",
                table: "AfterSaleCustomers",
                column: "shipping_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleCustomers_shipping_addressid",
                schema: "general",
                table: "AfterSaleCustomers",
                column: "shipping_addressid");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleEcommerces_address_id",
                schema: "general",
                table: "AfterSaleEcommerces",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleReasons_ecommerce_id",
                schema: "general",
                table: "AfterSaleReasons",
                column: "ecommerce_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleReverses_customer_id",
                schema: "general",
                table: "AfterSaleReverses",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleReverses_ecommerce_id",
                schema: "general",
                table: "AfterSaleReverses",
                column: "ecommerce_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleReverses_status_id",
                schema: "general",
                table: "AfterSaleReverses",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleStatusHistories_reverse_id",
                schema: "general",
                table: "AfterSaleStatusHistories",
                column: "reverse_id");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleStatusHistories_statusid",
                schema: "general",
                table: "AfterSaleStatusHistories",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_AfterSaleTrackingHistories_tracking_id",
                schema: "general",
                table: "AfterSaleTrackingHistories",
                column: "tracking_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfterSaleReasons",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleStatusHistories",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleTrackingHistories",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleTransportations",
                schema: "general");

            migrationBuilder.DropTable(
                name: "Parametros_AfterSale",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleReverses",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleCustomers",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleEcommerces",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleStatus",
                schema: "general");

            migrationBuilder.DropTable(
                name: "AfterSaleAddresses",
                schema: "general");
        }
    }
}
