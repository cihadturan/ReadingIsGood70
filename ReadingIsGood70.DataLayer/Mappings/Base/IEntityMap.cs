using Microsoft.EntityFrameworkCore;

namespace ReadingIsGood70.DataLayer.Mappings.Base
{
    public interface IEntityMap
    {
        void Map(ModelBuilder modelBuilder);
    }
}