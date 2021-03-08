namespace BillsToPay.Domain.BusinessRule
{
    using System.Collections.Generic;
    using System.Linq;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Exceptions;

    public static class CalculateCorrectedValue
    {
        public static decimal Execute(BillToPay billToPay, IEnumerable<LateFee> lateFees)
        {
            if (billToPay?.OriginalValue == null || lateFees is null)
                throw new ArgumentNullToApplyRuleException();

            if (billToPay.NumberOfDaysOverdue <= 0)
                return billToPay.OriginalValue.Value;

            var lateFee = lateFees
                .Where(l => l.MinDaysInOverdue < billToPay.NumberOfDaysOverdue)
                .Aggregate((last, cur) => last.MinDaysInOverdue > cur.MinDaysInOverdue ? last : cur);

            if(lateFee is null)
                throw new ArgumentNullToApplyRuleException();

            var originalValue = billToPay.OriginalValue.Value;
            var fee = originalValue * lateFee.Fee / 100;
            var lateAmount = originalValue * (lateFee.InterestPerDay / 100) * billToPay.NumberOfDaysOverdue;

            return originalValue + fee + lateAmount;
        }
    }
}