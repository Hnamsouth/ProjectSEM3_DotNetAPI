using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSEM3.Migrations
{
    /// <inheritdoc />
    public partial class create_database : Migration
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
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SizeType = table.Column<byte>(type: "tinyint", nullable: false)
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
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Activate = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07AE7F2844", x => x.Id);
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
                        name: "FK__Admins__user_id__19DFD96B",
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
                        name: "FK__Orders__user_id__282DF8C2",
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
                        name: "FK__UserCard__user_i__30C33EC3",
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
                        name: "FK__UserInfo__user_i__31B762FC",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    category_id = table.Column<int>(type: "int", nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "(CONVERT([tinyint],(0)))"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    OpenSale = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "(CONVERT([tinyint],(0)))"),
                    category_detail_id = table.Column<int>(type: "int", nullable: true),
                    kindofsport_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3214EC0726D18407", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Products__catego__2DE6D218",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Products__catego__41EDCAC5",
                        column: x => x.category_detail_id,
                        principalTable: "CategoryDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Products__kindof__40F9A68C",
                        column: x => x.kindofsport_id,
                        principalTable: "KindOfSport",
                        principalColumn: "Id");
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
                        name: "FK__Payment__order_i__29221CFB",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Payment__user_id__2A164134",
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
                name: "Favouries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favourie__3214EC0752A82DA1", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Favouries__produ__2180FB33",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Favouries__user___22751F6C",
                        column: x => x.user_id,
                        principalTable: "Users",
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
                        name: "FK__ProductRe__produ__2BFE89A6",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductRe__user___2CF2ADDF",
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
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    product_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductS__3214EC07D29ABF3C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ProductSi__produ__3A4CA8FD",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ProductSi__size___2FCF1A8A",
                        column: x => x.SizeId,
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
                    product_id = table.Column<int>(type: "int", nullable: true),
                    productSize_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Carts__3214EC07A226B5B5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Carts__productSi__1CBC4616",
                        column: x => x.productSize_id,
                        principalTable: "ProductSize",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Carts__product_i__1AD3FDA4",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Carts__user_id__1DB06A4F",
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
                    product_id = table.Column<int>(type: "int", nullable: true),
                    productSize_id = table.Column<int>(type: "int", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__3214EC070E1688EB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__OrderDeta__order__245D67DE",
                        column: x => x.order_id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__2645B050",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__OrderDeta__produ__2739D489",
                        column: x => x.productSize_id,
                        principalTable: "ProductSize",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdCampaign_collection_id",
                table: "AdCampaign",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_AdCampaign_partners_id",
                table: "AdCampaign",
                column: "partners_id");

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
                name: "IX_Favouries_product_id",
                table: "Favouries",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favouries_user_id",
                table: "Favouries",
                column: "user_id");

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
                name: "IX_OrderDetail_order_id",
                table: "OrderDetail",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_product_id",
                table: "OrderDetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_productSize_id",
                table: "OrderDetail",
                column: "productSize_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PartnersInfo_partners_id",
                table: "PartnersInfo",
                column: "partners_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_order_id",
                table: "Payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_user_id",
                table: "Payment",
                column: "user_id");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_product_id",
                table: "ProductReview",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_user_id",
                table: "ProductReview",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_detail_id",
                table: "Products",
                column: "category_detail_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_kindofsport_id",
                table: "Products",
                column: "kindofsport_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_product_id",
                table: "ProductSize",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizeId",
                table: "ProductSize",
                column: "SizeId");

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
                name: "UQ__Users__A9D10534B7ED3B19",
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
                name: "PartnersInfo");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ProductAdCampaign");

            migrationBuilder.DropTable(
                name: "ProductForChild");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "UserCard");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AdCampaign");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "CategoryDetail");

            migrationBuilder.DropTable(
                name: "KindOfSport");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
