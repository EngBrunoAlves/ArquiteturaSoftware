namespace BillsToPay.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BillsToPay.Domain.Validations;

    public class BillToPay : EntityBase
    {
        public BillToPay()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        [MaxLength(8000)]
        public string Name { get; set; }

        [Required]
        public decimal? OriginalValue { get; set; }

        [Required]
        [DateTimeRangeValidation]
        public DateTime? DueDate { get; set; }

        [Required]
        [DateTimeRangeValidation]
        public DateTime? PayDay { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfDaysOverdue { get; set; }
    }
}