using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSEM3.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ProductColor_ProductColorId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Favouries_ProductColor_ProductColorId",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductColor_ProductColorId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductColor_ProductColorId",
                table: "ProductSize");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_ProductColorId",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductColorId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_Favouries_ProductColorId",
                table: "Favouries");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductColorId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Favouries");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "ProductSize",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "(CONVERT([tinyint],(0)))",
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValueSql: "(CONVERT([tinyint],(0)))",
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_product_id",
                table: "ProductSize",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductSi__produ__3A4CA8FD",
                table: "ProductSize",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ProductSi__produ__3A4CA8FD",
                table: "ProductSize");

            migrationBuilder.DropIndex(
                name: "IX_ProductSize_product_id",
                table: "ProductSize");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "ProductSize");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "ProductSize",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Products",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "(CONVERT([tinyint],(0)))");

            migrationBuilder.AlterColumn<string>(
                name: "Img",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<byte>(
                name: "Gender",
                table: "Products",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValueSql: "(CONVERT([tinyint],(0)))");

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "OrderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "Favouries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    ColorName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Img = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__3214EC071B1CD27C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColor_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_ProductColorId",
                table: "ProductSize",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductColorId",
                table: "OrderDetail",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Favouries_ProductColorId",
                table: "Favouries",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductColorId",
                table: "Carts",
                column: "ProductColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_product_id",
                table: "ProductColor",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ProductColor_ProductColorId",
                table: "Carts",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favouries_ProductColor_ProductColorId",
                table: "Favouries",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductColor_ProductColorId",
                table: "OrderDetail",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductColor_ProductColorId",
                table: "ProductSize",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");
        }
    }
}
