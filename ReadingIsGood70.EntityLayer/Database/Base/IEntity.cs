using System;

namespace ReadingIsGood70.EntityLayer.Database.Base
{
    public interface IEntity
    {
        int Id { get; }
        Guid Uuid { get; }
    }
}