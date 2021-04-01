namespace BillsToPay.Repository.MongoDb.EntityConfig
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    interface IEntityBase
    {
        [BsonId]
        Guid Id { get; set; }

        [BsonIgnore]
        ObjectId ObjectId { get; }
    }
}
