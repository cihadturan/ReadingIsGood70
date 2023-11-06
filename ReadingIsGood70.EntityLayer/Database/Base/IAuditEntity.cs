using System;

namespace ReadingIsGood70.EntityLayer.Database.Base
{
    public interface IAuditEntity : IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}