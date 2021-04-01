namespace BillsToPay.Services.Rest.Models 
{
    public class BillsToPayConfig
    {
        public bool DatabaseConfigIsValid()
        {
            return UseMySql ^ UseMongoDb;
        }
        public bool UseMySql { get; set; }

        public bool UseMongoDb { get; set; }
    }
}