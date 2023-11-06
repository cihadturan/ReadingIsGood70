using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood70.DataLayer.Extensions;
using ReadingIsGood70.EntityLayer.Database.Base;

namespace ReadingIsGood70.DataLayer.Mappings.Base
{
    public abstract class EntityMap<TEntity> : IEntityMap where TEntity : class, IEntity
    {
        protected readonly List<IEntityMapComponent> EntityMapComponents;
        protected readonly string Schema;

        protected EntityMap(string schema)
        {
            Schema = schema;
            EntityMapComponents = new List<IEntityMapComponent>();

            if (typeof(TEntity).HasInterface<IEntity>()) EntityMapComponents.Add(new EntityMapComponent());
        }

        public abstract void Map(ModelBuilder modelBuilder);

        protected void MapTableAndSchema(EntityTypeBuilder<TEntity> entity)
        {
            entity.ToTable(
                typeof(TEntity).Name,
                string.IsNullOrEmpty(Schema) ? typeof(TEntity).LastNamespacePart() : Schema);
        }
    }
}