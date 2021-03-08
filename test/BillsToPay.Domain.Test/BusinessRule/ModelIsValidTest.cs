namespace BillsToPay.Domain.Test.BusinessRule
{
    using System;
    using BillsToPay.Domain.BusinessRule;
    using BillsToPay.Domain.Entities;
    using Xunit;

    public class ModelIsValidTest
    {
        [Fact]
        public void ModelIsValidResultTrue()
        {
            var modelToTest = new BillToPay
            {
                Name = "Market",
                OriginalValue = 10,
                PayDay = DateTime.UtcNow,
                DueDate = DateTime.Now.AddDays(5)
            };
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.True(result);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ModelIsValidResultFalseWithOneError()
        {
            const int expected = 1;
            var modelToTest = new BillToPay
            {
                OriginalValue = 10,
                PayDay = DateTime.UtcNow,
                DueDate = DateTime.Now.AddDays(5)
            };
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.False(result);
            Assert.NotEmpty(validationResults);
            Assert.Equal(expected, validationResults.Count);
        }

        [Fact]
        public void ModelIsValidResultFalseWithTwoError()
        {
            const int expected = 2;
            var modelToTest = new BillToPay
            {
                PayDay = DateTime.UtcNow,
                DueDate = DateTime.Now.AddDays(5)
            };
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.False(result);
            Assert.NotEmpty(validationResults);
            Assert.Equal(expected, validationResults.Count);
        }

        [Fact]
        public void ModelIsValidResultFalseWithThreeError()
        {
            const int expected = 3;
            var modelToTest = new BillToPay
            {
                DueDate = DateTime.Now.AddDays(5)
            };
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.False(result);
            Assert.NotEmpty(validationResults);
            Assert.Equal(expected, validationResults.Count);
        }

        [Fact]
        public void ModelIsValidResultFalseWithFourError()
        {
            const int expected = 4;
            var modelToTest = new BillToPay();
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.False(result);
            Assert.NotEmpty(validationResults);
            Assert.Equal(expected, validationResults.Count);
        }
    }
}