namespace BillsToPay.Repository.MongoDb.Models
{
	internal interface IBillsToPayMongoDbConfig
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}

	internal sealed class BillsToPayMongoDbConfig : IBillsToPayMongoDbConfig
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
