namespace BillsToPay.Domain.Entities
{
    public class LateFee : EntityBase
    {
        public int MinDaysInOverdue { get; set; }

        public decimal Fee { get; set; }

        public decimal InterestPerDay { get; set; }
    }
}