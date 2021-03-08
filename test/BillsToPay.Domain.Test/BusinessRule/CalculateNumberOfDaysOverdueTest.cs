namespace BillsToPay.Domain.Test.BusinessRule
{
    using System;
    using BillsToPay.Domain.BusinessRule;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Exceptions;
    using Xunit;

    public class CalculateNumberOfDaysOverdueTest
    {

        [Fact]
        public void CalculateNumberOfDaysAnticipatedResultZero()
        {
            const int expected = 0;
            var billToPay = CreateBillToPay;
            billToPay.PayDay = DateTime.UtcNow;
            billToPay.DueDate = DateTime.UtcNow.AddDays(1);

            var result = CalculateNumberOfDaysOverdue.Execute(billToPay);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateNumberOfDaysLateResultFive()
        {
            const int expected = 5;
            var billToPay = CreateBillToPay;
            billToPay.PayDay = DateTime.UtcNow.AddDays(5);
            billToPay.DueDate = DateTime.UtcNow;

            var result = CalculateNumberOfDaysOverdue.Execute(billToPay);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateNumberOfDaysLateResultTen()
        {
            const int expected = 10;
            var billToPay = CreateBillToPay;
            billToPay.PayDay = DateTime.UtcNow.AddDays(10).AddMinutes(1);
            billToPay.DueDate = DateTime.UtcNow;

            var result = CalculateNumberOfDaysOverdue.Execute(billToPay);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateNumberOfDaysInDayResultZero()
        {
            const int expected = 0;
            var billToPay = CreateBillToPay;
            billToPay.PayDay = DateTime.UtcNow;
            billToPay.DueDate = DateTime.UtcNow.AddMinutes(10);

            var result = CalculateNumberOfDaysOverdue.Execute(billToPay);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateNumberOfDaysWithoutDateResultThrow()
        {
            var billToPay = CreateBillToPay;

            Assert.Throws<ArgumentNullToApplyRuleException>(() => CalculateNumberOfDaysOverdue.Execute(billToPay));
        }

        private static BillToPay CreateBillToPay =>
            new BillToPay
            {
                Name = "Market",
                OriginalValue = 10
            };
    }
}