using System;
using System.Collections.Generic;
using ReadingIsGood70.EntityLayer.Database.Auth;
using ReadingIsGood70.EntityLayer.Database.Base;
using ReadingIsGood70.EntityLayer.Enum;

namespace ReadingIsGood70.EntityLayer.Database.Content
{
    public class Order : IAuditEntity
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string Address { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        #region IAuditEntity

        public int Id => OrderId;
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        #endregion
    }
}