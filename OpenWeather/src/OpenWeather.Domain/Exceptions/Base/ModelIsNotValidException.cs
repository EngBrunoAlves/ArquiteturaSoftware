namespace OpenWeather.Domain.Exceptions
{
    using System;

    public class ModelIsNotValidException : Exception
    {
        public ModelIsNotValidException() : base() { }
        public ModelIsNotValidException(string message) : base(message) { }
        public ModelIsNotValidException(string message, Exception innerException) : base(message, innerException) { }
    }
}