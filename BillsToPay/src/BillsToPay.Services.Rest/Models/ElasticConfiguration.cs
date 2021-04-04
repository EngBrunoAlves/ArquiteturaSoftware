namespace BillsToPay.Services.Rest.Models 
{
    public interface IElasticConfiguration
    {
        string Uri { get; set; }
    }

    public class ElasticConfiguration : IElasticConfiguration
    {
        public string Uri { get; set; }
    }
}