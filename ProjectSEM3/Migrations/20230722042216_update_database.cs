using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSEM3.Migrations
{
    /// <inheritdoc />
    public partial class update_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3214EC07DF9A41C9", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coupon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Size__3214EC07E98EF804", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07AE7F2844", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3214EC0726D18407", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Products__catego__398D8EEE",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admins__3214EC07E6E0EE75", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Admins__user_id__4F7CD00D",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Ship_Code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC074A5FA77D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__user_id__5DCAEF64",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCard",
                columns: table => new
                {
                    CardNumber = table.Column<int>(type: "int", nullable: false),
                    NameOnCard = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ExpiryDate = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    CVC = table.Column<byte>(type: "tinyint", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserCard__A4E9FFE8CFE115A2", x => x.CardNumber);
                    table.ForeignKey(
                        name: "FK__UserCard__user_i__6A30C649",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserInfo__3214EC07F4ADAEF8", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UserInfo__user_i__4BAC3F29",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DiscountProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Discount_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ColorName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductC__3214EC071B1CD27C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductCo__produ__3C69FB99",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductR__3214EC075CE6C025", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductRe__produ__6D0D32F4",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductRe__user___6E01572D",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__3214EC07D75A8B65", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Payment__order_i__66603565",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Payment__user_id__6754599E",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favouries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productColor_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favourie__3214EC0752A82DA1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Favouries__produ__5812160E",
                        column: x => x.productColor_id,
                        principalTable: "ProductColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Favouries__produ__59063A47",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Favouries__user___59FA5E80",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    size_id = table.Column<int>(type: "int", nullable: true),
                    productColor_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductS__3214EC07D29ABF3C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductSi__produ__440B1D61",
                        column: x => x.productColor_id,
                        principalTable: "ProductColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductSi__size___4316F928",
                        column: x => x.size_id,
                        principalTable: "Size",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buy_qty = table.Column<int>(type: "int", nullable: false),
                    productColor_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    productSize_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carts__3214EC07A226B5B5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Carts__productCo__52593CB8",
                        column: x => x.productColor_id,
                        principalTable: "ProductColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Carts__productSi__5441852A",
                        column: x => x.productSize_id,
                        principalTable: "ProductSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Carts__product_i__534D60F1",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Carts__user_id__5535A963",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    productColor_id = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    productSize_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC070E1688EB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__order__6383C8BA",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__60A75C0F",
                        column: x => x.productColor_id,
                        principalTable: "ProductColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__619B8048",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__628FA481",
                        column: x => x.productSize_id,
                        principalTable: "ProductSize",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_user_id",
                table: "Admins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Admins__DA15413E248224BD",
                table: "Admins",
                column: "Role",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_product_id",
                table: "Carts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_productColor_id",
                table: "Carts",
                column: "productColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_productSize_id",
                table: "Carts",
                column: "productSize_id");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_user_id",
                table: "Carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Categori__737584F60CB46E23",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_DiscountId",
                table: "DiscountProduct",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProduct_ProductId",
                table: "DiscountProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favouries_product_id",
                table: "Favouries",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favouries_productColor_id",
                table: "Favouries",
                column: "productColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favouries_user_id",
                table: "Favouries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_AdminId",
                table: "News",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_order_id",
                table: "OrderDetail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_product_id",
                table: "OrderDetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productColor_id",
                table: "OrderDetail",
                column: "productColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productSize_id",
                table: "OrderDetail",
                column: "productSize_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_order_id",
                table: "Payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_user_id",
                table: "Payment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColor_product_id",
                table: "ProductColor",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_product_id",
                table: "ProductReview",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_user_id",
                table: "ProductReview",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_productColor_id",
                table: "ProductSize",
                column: "productColor_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_size_id",
                table: "ProductSize",
                column: "size_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Size__737584F6F8BC285F",
                table: "Size",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCard_user_id",
                table: "UserCard",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_user_id",
                table: "UserInfo",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E41CC69CB7",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D10534FAE63181",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DiscountProduct");

            migrationBuilder.DropTable(
                name: "Favouries");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "UserCard");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
