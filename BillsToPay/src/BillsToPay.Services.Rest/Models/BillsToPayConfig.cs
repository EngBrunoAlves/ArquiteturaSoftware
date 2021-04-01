namespace BillsToPay.Services.Rest.Models 
{
    public interface IBillsToPayConfig
    {
        Database Database { get; set; }
    }

    public class BillsToPayConfig : IBillsToPayConfig
    {
        public Database Database { get; set; }
    }

    public enum Database
    {
        MySql = 0,
        MongoDb = 1
    }
}