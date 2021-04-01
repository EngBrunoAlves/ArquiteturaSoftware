using BillsToPay.Repository.MongoDb.Helpers;
using BillsToPay.Repository.MongoDb.Models;
using MongoDB.Driver;
using System;

namespace BillsToPay.Repository.MongoDb.Context
{
	internal sealed class BillsToPayContext : IDisposable
	{
		private readonly IBillsToPayMongoDbConfig _config;
		private MongoClient _client;
		private bool disposedValue;

		private MongoClient client => _client ??= new MongoClient(_config.ConnectionString);

		public BillsToPayContext(IBillsToPayMongoDbConfig config)
		{
			_config = config ?? throw new ArgumentNullException(nameof(config));
		}

		public IMongoCollection<T> GetCollection<T>()
		{
			var database = client.GetDatabase(_config.DatabaseName);
			var collectionName = CollectionNameHelper.GetCollectionName<T>();
			return database.GetCollection<T>(collectionName);
		}

		private void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_client = null;
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
