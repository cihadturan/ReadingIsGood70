﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadingIsGood70.EntityLayer.Database.Base;

namespace ReadingIsGood70.EntityLayer.Database.Content
{
    public class OrderDetail : IAuditEntity
    {
        public int Id => OrderDetailId;

        public Guid Uuid { get; set; }

        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal PriceSum { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
