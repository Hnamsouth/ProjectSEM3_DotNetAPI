using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSEM3.Migrations
{
    /// <inheritdoc />
    public partial class bcd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Carts__product_c__05D8E0BE",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__06CD04F7",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__catego__2DE6D218",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "ProductColor");

            migrationBuilder.RenameColumn(
                name: "product_color_id",
                table: "OrderDetail",
                newName: "product_size_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_product_color_id",
                table: "OrderDetail",
                newName: "IX_OrderDetail_product_size_id");

            migrationBuilder.RenameColumn(
                name: "product_color_id",
                table: "Carts",
                newName: "product_size_id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_product_color_id",
                table: "Carts",
                newName: "IX_Carts_product_size_id");

            migrationBuilder.CreateTable(
                name: "ProductColorImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    publicId = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Folder = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    asset_id = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    product_color_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__3214EC0744F31D6A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductCo__produ__0D7A0286",
                        column: x => x.product_color_id,
                        principalTable: "ProductColor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorImage_product_color_id",
                table: "ProductColorImage",
                column: "product_color_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__product_s__09A971A2",
                table: "Carts",
                column: "product_size_id",
                principalTable: "ProductSize",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__0A9D95DB",
                table: "OrderDetail",
                column: "product_size_id",
                principalTable: "ProductSize",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Carts__product_s__09A971A2",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__0A9D95DB",
                table: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductColorImage");

            migrationBuilder.RenameColumn(
                name: "product_size_id",
                table: "OrderDetail",
                newName: "product_color_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_product_size_id",
                table: "OrderDetail",
                newName: "IX_OrderDetail_product_color_id");

            migrationBuilder.RenameColumn(
                name: "product_size_id",
                table: "Carts",
                newName: "product_color_id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_product_size_id",
                table: "Carts",
                newName: "IX_Carts_product_color_id");

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "ProductColor",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__product_c__05D8E0BE",
                table: "Carts",
                column: "product_color_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__06CD04F7",
                table: "OrderDetail",
                column: "product_color_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__catego__2DE6D218",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
