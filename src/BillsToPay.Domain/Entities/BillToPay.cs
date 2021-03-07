namespace BillsToPay.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BillsToPay.Domain.Validations;

    public class BillToPay : EntityBase
    {
        [Required]
        [MaxLength(8000)]
        public string Name { get; set; }

        [Required]
        public decimal OriginalValue { get; set; }

        [Required]
        [DateTimeRangeValidation]
        public DateTime DueDate { get; set; }

        [Required]
        [DateTimeRangeValidation]
        public DateTime PayDay { get; set; }
    }
}