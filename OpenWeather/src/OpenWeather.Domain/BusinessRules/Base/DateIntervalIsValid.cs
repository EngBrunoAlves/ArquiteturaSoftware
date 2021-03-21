namespace OpenWeather.Domain.BusinessRules.Base
{
    using System;

    public static class DateIntervalIsValid
    {
        public static bool Execute(DateTime? starTime, DateTime? endTime)
        {
            return starTime.HasValue && endTime.HasValue && starTime.Value < endTime.Value;
        }
    }
}