namespace BillsToPay.Domain.Test.BusinessRule
{
    using System;
    using BillsToPay.Domain.BusinessRule;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Exceptions;
    using Xunit;

    public class CalculateCorrectedValueTest
    {
        [Fact]
        public void CalculateCorrectedValueWithoutOverdueResultSameOriginalValue()
        {
            var billToPay = CreateBillToPay;
            billToPay.PayDay = DateTime.UtcNow;
            billToPay.DueDate = DateTime.UtcNow.AddDays(1);

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(billToPay.OriginalValue, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithOverdueTwoDaysResultFirstFee()
        {
            const decimal expected = 10.22m;

            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 2;

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(expected, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithOverdueThreeDaysResultFirstFee()
        {
            const decimal expected = 10.23m;

            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 3;

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(expected, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithOverdueFourDaysResultSecondFee()
        {
            const decimal expected = 10.38m;

            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 4;

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(expected, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithOverdueFiveDaysResultSecondFee()
        {
            const decimal expected = 10.4m;

            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 5;

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(expected, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithOverdueSixDaysResultThirdFee()
        {
            const decimal expected = 10.68m;

            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 6;

            var lateFees = CreateLateFees;

            var correctedValue = CalculateCorrectedValue.Execute(billToPay, lateFees);
            Assert.Equal(expected, correctedValue);
        }

        [Fact]
        public void CalculateCorrectedValueWithoutLateFeesResultThrow()
        {
            var billToPay = CreateBillToPay;
            billToPay.NumberOfDaysOverdue = 0;

            Assert.Throws<ArgumentNullToApplyRuleException>(() => CalculateCorrectedValue.Execute(billToPay, null));
        }

        [Fact]
        public void CalculateCorrectedValueWithoutBillToPayResultThrow()
        {
            var lateFees = CreateLateFees;

            Assert.Throws<ArgumentNullToApplyRuleException>(() => CalculateCorrectedValue.Execute(null, lateFees));
        }

        [Fact]
        public void CalculateCorrectedValueWithoutOriginalValueResultThrow()
        {
            var billToPay = CreateBillToPay;
            billToPay.OriginalValue = null;
            var lateFees = CreateLateFees;

            Assert.Throws<ArgumentNullToApplyRuleException>(() => CalculateCorrectedValue.Execute(billToPay, lateFees));
        }

        private static BillToPay CreateBillToPay =>
            new BillToPay
            {
                Name = "Market",
                OriginalValue = 10,
                PayDay = null,
                DueDate = null
            };

        private static LateFee[] CreateLateFees =>
            new[]
            {
                new LateFee
                {
                    MinDaysInOverdue = 0,
                    Fee = 2,
                    InterestPerDay = 0.1m
                },
                new LateFee
                {
                    MinDaysInOverdue = 3,
                    Fee = 3,
                    InterestPerDay = 0.2m
                },
                new LateFee
                {
                    MinDaysInOverdue = 5,
                    Fee = 5,
                    InterestPerDay = 0.3m
                },
            };
    }
}