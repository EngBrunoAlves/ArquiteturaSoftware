namespace BillsToPay.Domain.Dtos
{
    using System;

    public class BillToPayLateDto
    {
        public string Name { get; set; }

        public decimal OriginalValue { get; set; }

        public decimal CorrectValue { get; set; }

        public int NumberOfDaysOverdue { get; set; }

        public DateTime PayDay { get; set; }
    }
}