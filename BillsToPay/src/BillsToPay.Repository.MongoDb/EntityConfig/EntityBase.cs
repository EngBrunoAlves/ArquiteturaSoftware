using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BillsToPay.Repository.MongoDb.EntityConfig
{
	interface IEntityBase
	{
		[BsonId]
		Guid Id { get; set; }

		[BsonIgnore]
		DateTime CreatedOn { get; }

		DateTime ModifiedOn { get; }

		[BsonIgnore]
		ObjectId ObjectId { get; }
	}
}
