using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectSEM3.Entities;

public partial class ProjectSem3Context : DbContext
{
    public ProjectSem3Context()
    {
    }

    public ProjectSem3Context(DbContextOptions<ProjectSem3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AdCampaign> AdCampaigns { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryDetail> CategoryDetails { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountProduct> DiscountProducts { get; set; }

    public virtual DbSet<Favoury> Favouries { get; set; }

    public virtual DbSet<KindOfSport> KindOfSports { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnersInfo> PartnersInfos { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAdCampaign> ProductAdCampaigns { get; set; }

    public virtual DbSet<ProductForChild> ProductForChildren { get; set; }

    public virtual DbSet<ProductReview> ProductReviews { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCard> UserCards { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SOUTH\\SQLEXPRESS;Initial Catalog=Project_SEM3;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdCampaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdCampai__3214EC07F7E8AE31");

            entity.ToTable("AdCampaign");

            entity.HasIndex(e => e.CollectionId, "IX_AdCampaign_collection_id");

            entity.HasIndex(e => e.PartnersId, "IX_AdCampaign_partners_id");

            entity.Property(e => e.CollectionId).HasColumnName("collection_id");
            entity.Property(e => e.Desciption).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Img).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OpenDate).HasColumnType("datetime");
            entity.Property(e => e.PartnersId).HasColumnName("partners_id");

            entity.HasOne(d => d.Collection).WithMany(p => p.AdCampaigns)
                .HasForeignKey(d => d.CollectionId)
                .HasConstraintName("FK__AdCampaig__colle__540C7B00");

            entity.HasOne(d => d.Partners).WithMany(p => p.AdCampaigns)
                .HasForeignKey(d => d.PartnersId)
                .HasConstraintName("FK__AdCampaig__partn__531856C7");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC07E6E0EE75");

            entity.HasIndex(e => e.UserId, "IX_Admins_user_id");

            entity.HasIndex(e => e.Role, "UQ__Admins__DA15413E248224BD").IsUnique();

            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Admins__user_id__19DFD96B");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC07A226B5B5");

            entity.HasIndex(e => e.ProductSizeId, "IX_Carts_productSize_id");

            entity.HasIndex(e => e.ProductId, "IX_Carts_product_id");

            entity.HasIndex(e => e.UserId, "IX_Carts_user_id");

            entity.Property(e => e.BuyQty).HasColumnName("buy_qty");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductSizeId).HasColumnName("productSize_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Carts__product_i__1AD3FDA4");

            entity.HasOne(d => d.ProductSize).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductSizeId)
                .HasConstraintName("FK__Carts__productSi__1CBC4616");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Carts__user_id__1DB06A4F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07DF9A41C9");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F60CB46E23").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<CategoryDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC071CD2494F");

            entity.ToTable("CategoryDetail");

            entity.HasIndex(e => e.CategoryId, "IX_CategoryDetail_category_id");

            entity.HasIndex(e => e.Name, "UQ__Category__737584F67976B658").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryDetails)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CategoryD__categ__40058253");
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collecti__3214EC070B2DCC12");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC074E2CC928");

            entity.ToTable("Discount");

            entity.Property(e => e.Coupon).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);
        });

        modelBuilder.Entity<DiscountProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07763F58C0");

            entity.ToTable("DiscountProduct");

            entity.HasIndex(e => e.DiscountId, "IX_DiscountProduct_Discount_id");

            entity.HasIndex(e => e.ProductId, "IX_DiscountProduct_Product_id");

            entity.Property(e => e.DiscountId).HasColumnName("Discount_id");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Discount).WithMany(p => p.DiscountProducts)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK__DiscountP__Disco__1EA48E88");

            entity.HasOne(d => d.Product).WithMany(p => p.DiscountProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__DiscountP__Produ__1F98B2C1");
        });

        modelBuilder.Entity<Favoury>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favourie__3214EC0752A82DA1");

            entity.HasIndex(e => e.ProductId, "IX_Favouries_product_id");

            entity.HasIndex(e => e.UserId, "IX_Favouries_user_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Favouries)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Favouries__produ__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.Favouries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Favouries__user___22751F6C");
        });

        modelBuilder.Entity<KindOfSport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KindOfSp__3214EC077F32249A");

            entity.ToTable("KindOfSport");

            entity.HasIndex(e => e.Name, "UQ__KindOfSp__737584F6CDD7C52D").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC077F5C2BFE");

            entity.HasIndex(e => e.AdminId, "IX_News_Admin_id");

            entity.Property(e => e.AdminId).HasColumnName("Admin_id");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.ShortDescription).HasMaxLength(255);
            entity.Property(e => e.Thumbnail).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.Admin).WithMany(p => p.News)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK__News__Admin_id__236943A5");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC074A5FA77D");

            entity.HasIndex(e => e.UserId, "IX_Orders_user_id");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.ShipCode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Ship_Code");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__user_id__282DF8C2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC070E1688EB");

            entity.ToTable("OrderDetail");

            entity.HasIndex(e => e.OrderId, "IX_OrderDetail_order_id");

            entity.HasIndex(e => e.ProductSizeId, "IX_OrderDetail_productSize_id");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetail_product_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductSizeId).HasColumnName("productSize_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__order__245D67DE");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__produ__2645B050");

            entity.HasOne(d => d.ProductSize).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductSizeId)
                .HasConstraintName("FK__OrderDeta__produ__2739D489");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC070E70813E");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.RepresentativeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartnersInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partners__3214EC07AA9DB02A");

            entity.ToTable("PartnersInfo");

            entity.HasIndex(e => e.PartnersId, "IX_PartnersInfo_partners_id");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Img).IsUnicode(false);
            entity.Property(e => e.PartnersId).HasColumnName("partners_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Partners).WithMany(p => p.PartnersInfos)
                .HasForeignKey(d => d.PartnersId)
                .HasConstraintName("FK__PartnersI__partn__4E53A1AA");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC07D75A8B65");

            entity.ToTable("Payment");

            entity.HasIndex(e => e.OrderId, "IX_Payment_order_id");

            entity.HasIndex(e => e.UserId, "IX_Payment_user_id");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payment__order_i__29221CFB");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payment__user_id__2A164134");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0726D18407");

            entity.HasIndex(e => e.CategoryDetailId, "IX_Products_category_detail_id");

            entity.HasIndex(e => e.CategoryId, "IX_Products_category_id");

            entity.HasIndex(e => e.KindofsportId, "IX_Products_kindofsport_id");

            entity.Property(e => e.CategoryDetailId).HasColumnName("category_detail_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Gender).HasDefaultValueSql("(CONVERT([tinyint],(0)))");
            entity.Property(e => e.Img).HasDefaultValueSql("(N'')");
            entity.Property(e => e.KindofsportId).HasColumnName("kindofsport_id");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OpenSale)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.Status).HasDefaultValueSql("(CONVERT([tinyint],(0)))");

            entity.HasOne(d => d.CategoryDetail).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryDetailId)
                .HasConstraintName("FK__Products__catego__41EDCAC5");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__catego__2DE6D218");

            entity.HasOne(d => d.Kindofsport).WithMany(p => p.Products)
                .HasForeignKey(d => d.KindofsportId)
                .HasConstraintName("FK__Products__kindof__40F9A68C");
        });

        modelBuilder.Entity<ProductAdCampaign>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductAdCampaign");

            entity.HasIndex(e => e.AdcampaignId, "IX_ProductAdCampaign_adcampaign_id");

            entity.HasIndex(e => e.ProductId, "IX_ProductAdCampaign_product_id");

            entity.Property(e => e.AdcampaignId).HasColumnName("adcampaign_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Adcampaign).WithMany()
                .HasForeignKey(d => d.AdcampaignId)
                .HasConstraintName("FK__ProductAd__adcam__56E8E7AB");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductAd__produ__55F4C372");
        });

        modelBuilder.Entity<ProductForChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductF__3214EC071774F8E7");

            entity.ToTable("ProductForChild");

            entity.HasIndex(e => e.ProductId, "IX_ProductForChild_product_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductForChildren)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductFo__produ__46B27FE2");
        });

        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC075CE6C025");

            entity.ToTable("ProductReview");

            entity.HasIndex(e => e.ProductId, "IX_ProductReview_product_id");

            entity.HasIndex(e => e.UserId, "IX_ProductReview_user_id");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductRe__produ__2BFE89A6");

            entity.HasOne(d => d.User).WithMany(p => p.ProductReviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ProductRe__user___2CF2ADDF");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductS__3214EC07D29ABF3C");

            entity.ToTable("ProductSize");

            entity.HasIndex(e => e.SizeId, "IX_ProductSize_SizeId");

            entity.HasIndex(e => e.ProductId, "IX_ProductSize_product_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductSi__produ__3A4CA8FD");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__ProductSi__size___2FCF1A8A");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Size__3214EC07E98EF804");

            entity.ToTable("Size");

            entity.HasIndex(e => e.Name, "UQ__Size__737584F6F8BC285F").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07AE7F2844");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B7ED3B19").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.Token).HasColumnType("text");
        });

        modelBuilder.Entity<UserCard>(entity =>
        {
            entity.HasKey(e => e.CardNumber).HasName("PK__UserCard__A4E9FFE8CFE115A2");

            entity.ToTable("UserCard");

            entity.HasIndex(e => e.UserId, "IX_UserCard_user_id");

            entity.Property(e => e.CardNumber).ValueGeneratedNever();
            entity.Property(e => e.Cvc).HasColumnName("CVC");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.NameOnCard)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserCards)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCard__user_i__30C33EC3");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserInfo__3214EC07F4ADAEF8");

            entity.ToTable("UserInfo");

            entity.HasIndex(e => e.UserId, "IX_UserInfo_user_id");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserInfo__user_i__31B762FC");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voucher__3214EC0765F26938");

            entity.ToTable("Voucher");

            entity.Property(e => e.Coupon).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DiscountFlat).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.DiscountPercent).HasColumnType("decimal(3, 1)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
