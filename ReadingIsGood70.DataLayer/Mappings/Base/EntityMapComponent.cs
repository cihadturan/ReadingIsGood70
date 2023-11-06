using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingIsGood70.DataLayer.Extensions;
using ReadingIsGood70.EntityLayer.Database.Base;

namespace ReadingIsGood70.DataLayer.Mappings.Base
{
    public class EntityMapComponent : IEntityMapComponent
    {
        public void Map(EntityTypeBuilder entity)
        {
            // ignore
            entity.Ignore(nameof(IEntity.Id));

            // identifier
            entity.HasIndex(nameof(IEntity.Uuid)).IsUnique();
            entity.Property(nameof(IEntity.Uuid)).HasDefaultNewId();
        }
    }
}