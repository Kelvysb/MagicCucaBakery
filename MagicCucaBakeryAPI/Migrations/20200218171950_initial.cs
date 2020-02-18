using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicCucaBakery.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coisas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coisas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_Number = table.Column<string>(nullable: true),
                    Address_Complement = table.Column<string>(nullable: true),
                    Address_Neighborhood = table.Column<string>(nullable: true),
                    Address_PostalCode = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordChange = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Observation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coisas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Banana" });

            migrationBuilder.InsertData(
                table: "Coisas",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Alabarda" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Active", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, true, "", "Customer", "Default", "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "Name", "Price", "Weight" },
                values: new object[] { 1, true, "Classic cuca Banana with white chocolate, covered with sweet farofa", "Cuca - Banana with white chocolate", 25.0, 2.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "Name", "Price", "Weight" },
                values: new object[] { 2, true, "Cuca with strawberries, covered with sweet farofa", "Cuca - Strawberries", 27.0, 2.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "Name", "Price", "Weight" },
                values: new object[] { 3, true, "Cuca with dark chocolate, covered with sweet farofa", "Cuca - chocolate", 25.0, 2.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Description", "Name", "Price", "Weight" },
                values: new object[] { 4, true, "Cuca special with classic Recife's desert and white chocolate, covered with sweet farofa", "Cuca - Bolo-de-Rolo", 30.0, 2.5 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "PasswordChange", "PasswordHash" },
                values: new object[] { 1, null, "Admin", "Admin", true, "e3afed0047b08059d0fada10f400c1e5" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coisas");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
