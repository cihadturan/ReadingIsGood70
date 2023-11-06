using Microsoft.EntityFrameworkCore;
using ReadingIsGood70.DataLayer.Mappings.Base;
using ReadingIsGood70.EntityLayer.Database.Content;

namespace ReadingIsGood70.DataLayer.Mappings
{
    public class ProductMap : EntityMap<Product>
    {
        public ProductMap(string schema = "") : base(schema)
        {
        }

        public override void Map(ModelBuilder modelBuilder)
        {
            // get entity builder reference
            var entity = modelBuilder.Entity<Product>();

            // set table name and schema
            MapTableAndSchema(entity);

            // apply component mappings
            EntityMapComponents.ForEach(c => c.Map(entity));

            // identifier
            entity.HasKey(p => p.ProductId);
            entity.Property(p => p.ProductId).UseIdentityColumn();
        }
    }
}