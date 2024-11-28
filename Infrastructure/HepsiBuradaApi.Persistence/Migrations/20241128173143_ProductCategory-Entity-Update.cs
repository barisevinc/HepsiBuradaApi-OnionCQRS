using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HepsiBuradaApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductCategoryEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 536, DateTimeKind.Local).AddTicks(3557), "Grocery, Sports & Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 536, DateTimeKind.Local).AddTicks(4145), "Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 536, DateTimeKind.Local).AddTicks(4257), "Health & Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 20, 31, 42, 537, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 20, 31, 42, 537, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 20, 31, 42, 537, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 20, 31, 42, 537, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 551, DateTimeKind.Local).AddTicks(6436), "Ut tv adanaya aspernatur voluptatem.", "Dolorem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 551, DateTimeKind.Local).AddTicks(6516), "Masanın voluptatem telefonu eum deleniti.", "Laudantium." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 551, DateTimeKind.Local).AddTicks(6546), "Gördüm dergi karşıdakine dicta eos.", "Ea." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 563, DateTimeKind.Local).AddTicks(5498), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Gorgeous Rubber Hat" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 31, 42, 563, DateTimeKind.Local).AddTicks(5553), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Small Soft Tuna" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 828, DateTimeKind.Local).AddTicks(9509), "Tools, Toys & Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(346), "Home & Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(362), "Jewelery & Automotive" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 23, 0, 58, 829, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 843, DateTimeKind.Local).AddTicks(6898), "Voluptatem yaptı otobüs adipisci değerli.", "Non." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 843, DateTimeKind.Local).AddTicks(6960), "Quae uzattı voluptate balıkhaneye sevindi.", "Uzattı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 843, DateTimeKind.Local).AddTicks(6986), "Vel dignissimos qui nisi voluptatem.", "Gül." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 847, DateTimeKind.Local).AddTicks(5848), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Practical Frozen Soap" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 25, 23, 0, 58, 847, DateTimeKind.Local).AddTicks(5895), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "Incredible Soft Bike" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
