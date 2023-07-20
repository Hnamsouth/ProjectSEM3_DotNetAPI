using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class OrderDetailDto
	{
        public int Id { get; set; }

        public int Qty { get; set; }

        public int? ProductColorId { get; set; }

        public int? ProductId { get; set; }

        public int? ProductSizeId { get; set; }

        public int? OrderId { get; set; }

        public virtual Order? Order { get; set; }

        public virtual Product? Product { get; set; }

        public virtual ProductColor? ProductColor { get; set; }

        public virtual ProductSize? ProductSize { get; set; }
    }
}

