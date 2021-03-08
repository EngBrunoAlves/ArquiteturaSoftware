namespace BillsToPay.Application.ViewModels
{
    using BillsToPay.Application.Validations;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BillToPayViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [MaxLength(8000, ErrorMessage = "Character limit exceeded")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        public decimal? OriginalValue { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DateTimeRangeValidation(ErrorMessage = "Date outside the allowed period")]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DateTimeRangeValidation(ErrorMessage = "Date outside the allowed period")]
        public DateTime? PayDay { get; set; }
    }
}