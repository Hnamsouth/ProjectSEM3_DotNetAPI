using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSEM3.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Admins__user_id__4F7CD00D",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__productCo__52593CB8",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__productSi__5441852A",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__product_i__534D60F1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__user_id__5535A963",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Favouries__produ__5812160E",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK__Favouries__produ__59063A47",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK__Favouries__user___59FA5E80",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__order__6383C8BA",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__60A75C0F",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__619B8048",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__628FA481",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__user_id__5DCAEF64",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Payment__order_i__66603565",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK__Payment__user_id__6754599E",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductCo__produ__3C69FB99",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductRe__produ__6D0D32F4",
                table: "ProductReview");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductRe__user___6E01572D",
                table: "ProductReview");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__catego__398D8EEE",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductSi__produ__440B1D61",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductSi__size___4316F928",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK__UserCard__user_i__6A30C649",
                table: "UserCard");

            migrationBuilder.DropForeignKey(
                name: "FK__UserInfo__user_i__4BAC3F29",
                table: "UserInfo");

            migrationBuilder.RenameColumn(
                name: "size_id",
                table: "ProductSize",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "productColor_id",
                table: "ProductSize",
                newName: "ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_size_id",
                table: "ProductSize",
                newName: "IX_ProductSize_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_productColor_id",
                table: "ProductSize",
                newName: "IX_ProductSize_ProductColorId");

            migrationBuilder.RenameColumn(
                name: "productColor_id",
                table: "OrderDetail",
                newName: "ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_productColor_id",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductColorId");

            migrationBuilder.RenameColumn(
                name: "productColor_id",
                table: "Favouries",
                newName: "ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Favouries_productColor_id",
                table: "Favouries",
                newName: "IX_Favouries_ProductColorId");

            migrationBuilder.RenameColumn(
                name: "productColor_id",
                table: "Carts",
                newName: "ProductColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_productColor_id",
                table: "Carts",
                newName: "IX_Carts_ProductColorId");

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenSale",
                table: "Products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "category_detail_id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "kindofsport_id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC071CD2494F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__CategoryD__categ__40058253",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Collecti__3214EC070B2DCC12", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC074E2CC928", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KindOfSport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KindOfSp__3214EC077F32249A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Update_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Admin_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__3214EC077F5C2BFE", x => x.Id);
                    table.ForeignKey(
                        name: "FK__News__Admin_id__236943A5",
                        column: x => x.Admin_id,
                        principalTable: "Admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepresentativeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partners__3214EC070E70813E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductForChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductF__3214EC071774F8E7", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductFo__produ__46B27FE2",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    DiscountFlat = table.Column<decimal>(type: "decimal(12,4)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Voucher__3214EC0765F26938", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_id = table.Column<int>(type: "int", nullable: true),
                    Discount_id = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3214EC07763F58C0", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DiscountP__Disco__1EA48E88",
                        column: x => x.Discount_id,
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__DiscountP__Produ__1F98B2C1",
                        column: x => x.Product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Img = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Desciption = table.Column<string>(type: "text", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    partners_id = table.Column<int>(type: "int", nullable: true),
                    collection_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AdCampai__3214EC07F7E8AE31", x => x.Id);
                    table.ForeignKey(
                        name: "FK__AdCampaig__colle__540C7B00",
                        column: x => x.collection_id,
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__AdCampaig__partn__531856C7",
                        column: x => x.partners_id,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartnersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Img = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    partners_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Partners__3214EC07AA9DB02A", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PartnersI__partn__4E53A1AA",
                        column: x => x.partners_id,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductAdCampaign",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: true),
                    adcampaign_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__ProductAd__adcam__56E8E7AB",
                        column: x => x.adcampaign_id,
                        principalTable: "AdCampaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductAd__produ__55F4C372",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_detail_id",
                table: "Products",
                column: "category_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kindofsport_id",
                table: "Products",
                column: "kindofsport_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdCampaign_collection_id",
                table: "AdCampaign",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdCampaign_partners_id",
                table: "AdCampaign",
                column: "partners_id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDetail_category_id",
                table: "CategoryDetail",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Category__737584F67976B658",
                table: "CategoryDetail",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_Discount_id",
                table: "DiscountProduct",
                column: "Discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_Product_id",
                table: "DiscountProduct",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "UQ__KindOfSp__737584F6CDD7C52D",
                table: "KindOfSport",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_Admin_id",
                table: "News",
                column: "Admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_PartnersInfo_partners_id",
                table: "PartnersInfo",
                column: "partners_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdCampaign_adcampaign_id",
                table: "ProductAdCampaign",
                column: "adcampaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAdCampaign_product_id",
                table: "ProductAdCampaign",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductForChild_product_id",
                table: "ProductForChild",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Admins__user_id__19DFD96B",
                table: "Admins",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ProductColor_ProductColorId",
                table: "Carts",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__productSi__1CBC4616",
                table: "Carts",
                column: "productSize_id",
                principalTable: "ProductSize",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__product_i__1AD3FDA4",
                table: "Carts",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__user_id__1DB06A4F",
                table: "Carts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favouries_ProductColor_ProductColorId",
                table: "Favouries",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Favouries__produ__2180FB33",
                table: "Favouries",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Favouries__user___22751F6C",
                table: "Favouries",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_ProductColor_ProductColorId",
                table: "OrderDetail",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__order__245D67DE",
                table: "OrderDetail",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__2645B050",
                table: "OrderDetail",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__2739D489",
                table: "OrderDetail",
                column: "productSize_id",
                principalTable: "ProductSize",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__user_id__282DF8C2",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payment__order_i__29221CFB",
                table: "Payment",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payment__user_id__2A164134",
                table: "Payment",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Products_product_id",
                table: "ProductColor",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductRe__produ__2BFE89A6",
                table: "ProductReview",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductRe__user___2CF2ADDF",
                table: "ProductReview",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__catego__2DE6D218",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__catego__41EDCAC5",
                table: "Products",
                column: "category_detail_id",
                principalTable: "CategoryDetail",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__kindof__40F9A68C",
                table: "Products",
                column: "kindofsport_id",
                principalTable: "KindOfSport",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_ProductColor_ProductColorId",
                table: "ProductSize",
                column: "ProductColorId",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductSi__size___2FCF1A8A",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserCard__user_i__30C33EC3",
                table: "UserCard",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserInfo__user_i__31B762FC",
                table: "UserInfo",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Admins__user_id__19DFD96B",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ProductColor_ProductColorId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__productSi__1CBC4616",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__product_i__1AD3FDA4",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK__Carts__user_id__1DB06A4F",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Favouries_ProductColor_ProductColorId",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK__Favouries__produ__2180FB33",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK__Favouries__user___22751F6C",
                table: "Favouries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_ProductColor_ProductColorId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__order__245D67DE",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__2645B050",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__OrderDeta__produ__2739D489",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__user_id__282DF8C2",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK__Payment__order_i__29221CFB",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK__Payment__user_id__2A164134",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Products_product_id",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductRe__produ__2BFE89A6",
                table: "ProductReview");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductRe__user___2CF2ADDF",
                table: "ProductReview");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__catego__2DE6D218",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__catego__41EDCAC5",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK__Products__kindof__40F9A68C",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_ProductColor_ProductColorId",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK__ProductSi__size___2FCF1A8A",
                table: "ProductSize");

            migrationBuilder.DropForeignKey(
                name: "FK__UserCard__user_i__30C33EC3",
                table: "UserCard");

            migrationBuilder.DropForeignKey(
                name: "FK__UserInfo__user_i__31B762FC",
                table: "UserInfo");

            migrationBuilder.DropTable(
                name: "CategoryDetail");

            migrationBuilder.DropTable(
                name: "DiscountProduct");

            migrationBuilder.DropTable(
                name: "KindOfSport");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PartnersInfo");

            migrationBuilder.DropTable(
                name: "ProductAdCampaign");

            migrationBuilder.DropTable(
                name: "ProductForChild");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "AdCampaign");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Products_category_detail_id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_kindofsport_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OpenSale",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "category_detail_id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "kindofsport_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "ProductSize",
                newName: "size_id");

            migrationBuilder.RenameColumn(
                name: "ProductColorId",
                table: "ProductSize",
                newName: "productColor_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                newName: "IX_ProductSize_size_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSize_ProductColorId",
                table: "ProductSize",
                newName: "IX_ProductSize_productColor_id");

            migrationBuilder.RenameColumn(
                name: "ProductColorId",
                table: "OrderDetail",
                newName: "productColor_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductColorId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_productColor_id");

            migrationBuilder.RenameColumn(
                name: "ProductColorId",
                table: "Favouries",
                newName: "productColor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Favouries_ProductColorId",
                table: "Favouries",
                newName: "IX_Favouries_productColor_id");

            migrationBuilder.RenameColumn(
                name: "ProductColorId",
                table: "Carts",
                newName: "productColor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ProductColorId",
                table: "Carts",
                newName: "IX_Carts_productColor_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Admins__user_id__4F7CD00D",
                table: "Admins",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__productCo__52593CB8",
                table: "Carts",
                column: "productColor_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__productSi__5441852A",
                table: "Carts",
                column: "productSize_id",
                principalTable: "ProductSize",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__product_i__534D60F1",
                table: "Carts",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Carts__user_id__5535A963",
                table: "Carts",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Favouries__produ__5812160E",
                table: "Favouries",
                column: "productColor_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Favouries__produ__59063A47",
                table: "Favouries",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Favouries__user___59FA5E80",
                table: "Favouries",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__order__6383C8BA",
                table: "OrderDetail",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__60A75C0F",
                table: "OrderDetail",
                column: "productColor_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__619B8048",
                table: "OrderDetail",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__OrderDeta__produ__628FA481",
                table: "OrderDetail",
                column: "productSize_id",
                principalTable: "ProductSize",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__user_id__5DCAEF64",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payment__order_i__66603565",
                table: "Payment",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Payment__user_id__6754599E",
                table: "Payment",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductCo__produ__3C69FB99",
                table: "ProductColor",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductRe__produ__6D0D32F4",
                table: "ProductReview",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductRe__user___6E01572D",
                table: "ProductReview",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Products__catego__398D8EEE",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductSi__produ__440B1D61",
                table: "ProductSize",
                column: "productColor_id",
                principalTable: "ProductColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__ProductSi__size___4316F928",
                table: "ProductSize",
                column: "size_id",
                principalTable: "Size",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserCard__user_i__6A30C649",
                table: "UserCard",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__UserInfo__user_i__4BAC3F29",
                table: "UserInfo",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
