using Microsoft.EntityFrameworkCore;
using ReadingIsGood70.DataLayer.Mappings.Base;
using ReadingIsGood70.EntityLayer.Database.Content;
using ReadingIsGood70.EntityLayer.Enum;
using ReadingIsGood70.Utils.Extensions;

namespace ReadingIsGood70.DataLayer.Mappings
{
    public class OrderDetailMap : EntityMap<OrderDetail>
    {
        public OrderDetailMap(string schema = "") : base(schema)
        {
        }

        public override void Map(ModelBuilder modelBuilder)
        {
            // get entity builder reference
            var entity = modelBuilder.Entity<OrderDetail>();

            // set table name and schema
            MapTableAndSchema(entity);

            // apply component mappings
            EntityMapComponents.ForEach(c => c.Map(entity));

            // identifier
            entity.HasKey(p => p.OrderDetailId);
            entity.Property(p => p.OrderDetailId).UseIdentityColumn();

            entity.HasOne(r => r.Order).WithMany(x => x.OrderDetails);
            entity.HasOne(x => x.Product).WithMany(x => x.OrderDetails);
        }
    }
}