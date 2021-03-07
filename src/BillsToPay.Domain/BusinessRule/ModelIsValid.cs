namespace BillsToPay.Domain.BusinessRule
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public static class ModelIsValid
    {
        public static bool Execute<TEntity>(TEntity entity, out IList<ValidationResult> validationResults)
        {
            var context = new ValidationContext(entity, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(entity, context, validationResults, true);
        }
    }
}