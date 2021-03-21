namespace OpenWeather.Domain.Exceptions
{
    using System;

    public class DateIntervalIsNotValidException : Exception
    {
        public DateIntervalIsNotValidException() : base() { }
        public DateIntervalIsNotValidException(string message) : base(message) { }
        public DateIntervalIsNotValidException(string message, Exception innerException) : base(message, innerException) { }
    }
}