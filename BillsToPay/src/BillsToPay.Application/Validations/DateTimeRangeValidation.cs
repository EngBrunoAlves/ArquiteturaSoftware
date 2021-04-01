namespace BillsToPay.Application.Validations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    internal class DateTimeRangeValidationAttribute : RangeAttribute
    {
        public DateTimeRangeValidationAttribute()
            : base(typeof(DateTime), DateTime.MinValue.ToLongDateString(), DateTime.MaxValue.ToLongDateString()) { }
    }
}