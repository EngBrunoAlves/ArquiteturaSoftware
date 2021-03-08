namespace BillsToPay.Domain.BusinessRule
{
    using System;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Exceptions;

    public static class CalculateNumberOfDaysOverdue
    {
        public static int Execute(BillToPay billToPay)
        {
            if(!billToPay.PayDay.HasValue || !billToPay.DueDate.HasValue)
                throw new ArgumentNullToApplyRuleException();

            if (billToPay.PayDay < billToPay.DueDate)
                return 0;

            var payDay = NormalizeDate(billToPay.PayDay.Value);

            var dueDate = NormalizeDate(billToPay.DueDate.Value);

            return (payDay - dueDate).Days;
        }

        private static DateTime NormalizeDate(DateTime date) =>
            new DateTime(date.Year, date.Month, date.Day);
    }
}