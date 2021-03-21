namespace OpenWeather.Domain.Test.BusinessRules.Base
{
    using System;
    using OpenWeather.Domain.BusinessRules.Base;
    using OpenWeather.Domain.Entities;
    using Xunit;

    public class ModelIsValidTest
    {
        [Fact]
        public void ModelIsValidResultTrue()
        {
            var modelToTest = new Weather
            {
                City = "Test City",
                CreatedDate = DateTime.UtcNow,
                Temperature = 28.5
            };
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.True(result);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void ModelIsValidResultFalseWithOneError()
        {
            const int expected = 1;
            var modelToTest = new Weather
            {
                City = "Test City",
                CreatedDate = DateTime.UtcNow,
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
            var modelToTest = new Weather
            {
                City = "Test City"
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
            var modelToTest = new Weather();
            var result = ModelIsValid.Execute(modelToTest, out var validationResults);

            Assert.False(result);
            Assert.NotEmpty(validationResults);
            Assert.Equal(expected, validationResults.Count);
        }
    }
}