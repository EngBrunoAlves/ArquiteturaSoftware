namespace BillsToPay.Domain.Exceptions
{
    using System;

    public class ArgumentNullToApplyRuleException : Exception
    {
        public ArgumentNullToApplyRuleException() : base() { }
        
        public ArgumentNullToApplyRuleException(string message) : base(message) { }
        
        public ArgumentNullToApplyRuleException(string message, Exception innerException) : base(message, innerException) { }
    }
}