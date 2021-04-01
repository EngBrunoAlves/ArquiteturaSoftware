using BillsToPay.Repository.MongoDb.Attributes;
using System.Reflection;

namespace BillsToPay.Repository.MongoDb.Helpers
{
	internal static class CollectionNameHelper
	{
		public static string GetCollectionName<T>()
		{
			var collectionName =
				typeof(T).GetTypeInfo().BaseType.Equals(typeof(object))
				? GetCollectionNameFromInterface<T>() 
				: GetCollectionNameFromType<T>();

			if (string.IsNullOrEmpty(collectionName))
				collectionName = typeof(T).Name;

			return collectionName.ToLowerInvariant();
		}

		private static string GetCollectionNameFromInterface<T>() =>
			CustomAttributeExtensions.GetCustomAttribute<CollectionNameAttribute>(typeof(T).GetTypeInfo().Assembly)?.Name ?? typeof(T).Name;

		private static string GetCollectionNameFromType<T>()
		{
			var entitytype = typeof(T);

			var att = CustomAttributeExtensions.GetCustomAttribute<CollectionNameAttribute>(typeof(T).GetTypeInfo().Assembly);

			return att != null ? att.Name : entitytype.Name;
		}
	}
}
