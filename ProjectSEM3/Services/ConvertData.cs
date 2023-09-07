using ProjectSEM3.Entities;

namespace ProjectSEM3.Services
{
    public class ConvertData
    {
        public static Object Products (Product e)
        {
            return new
            {
                e.Id,
                e.Name,
                e.Price,
                e.Description,
                e.Gender,
                e.OpenSale,
                e.Status,
                categoryDetail = new { e.CategoryDetail?.Id, e.CategoryDetail?.Name, e.CategoryDetail?.Category },
                e.Kindofsport,
                productColors = e.ProductColors.Select(a => new
                {
                    a.Id,
                    a.Name,
                    a.ProductId,
                    a.ProductColorImages,
                    productSizes = a.ProductSizes.Select(s => new { s.Id, s.Qty, s.SizeId, s.ProductColorId, s.Size })
                }),
            };
        }

        public static Object Carts(Cart e)
        {
            return new
            {
                e.Id,
                e.BuyQty,
                e.UserId,
                e.ProductSizeId,
                ProductSize = new
                {
                    e.ProductSize.Id,
                    e.ProductSize.Qty,
                    e.ProductSize.SizeId,
                    e.ProductSize.ProductColorId,
                    e.ProductSize.Size,
                    ProductColor = new
                    {
                        e.ProductSize.ProductColor.Id,
                        e.ProductSize.ProductColor.Name,
                        e.ProductSize.ProductColor.ProductId,
                        e.ProductSize.ProductColor.Product,
                        e.ProductSize.ProductColor.ProductColorImages

                    }
                }
            };
        }

    }
}
