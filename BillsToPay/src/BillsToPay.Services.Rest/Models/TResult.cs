namespace BillsToPay.Services.Rest.Models
{
    public class TResult
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class TResult<T> : TResult
    {
        public T Result { get; set; }
    }
}