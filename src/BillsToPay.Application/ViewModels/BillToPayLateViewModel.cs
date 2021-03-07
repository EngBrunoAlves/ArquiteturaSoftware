namespace BillsToPay.Application.ViewModels
{
    using System;

    public class BillToPayLateViewModel
    {
        public string Name { get; set; }

        public decimal OriginalValue { get; set; }

        public decimal CorrectValue { get; set; }

        public int NumberOfDaysOverdue { get; set; }

        public DateTime PayDay { get; set; }
    }
}