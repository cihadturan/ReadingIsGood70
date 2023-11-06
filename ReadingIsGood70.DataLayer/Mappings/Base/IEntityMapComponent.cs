using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReadingIsGood70.DataLayer.Mappings.Base
{
    public interface IEntityMapComponent
    {
        void Map(EntityTypeBuilder entity);
    }
}