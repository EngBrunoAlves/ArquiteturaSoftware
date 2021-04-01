using System;

namespace BillsToPay.Repository.MongoDb.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	internal sealed class CollectionNameAttribute : Attribute
	{
		public CollectionNameAttribute(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentException("Empty collection name is not allowed", nameof(value));
			Name = value;
		}

		public virtual string Name { get; private set; }
	}
}
