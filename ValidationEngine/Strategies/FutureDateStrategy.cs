using ValidationEngine.Core;

namespace ValidationEngine.Strategies
{
    public class FutureDateStrategy : IValidationRule
    {
        public ValidationResult? Validate(string propertyName, object value, Attribute attribute)
        {
            if (value is DateTime date && date <= DateTime.Now)
            {
                return new ValidationResult(propertyName, "Date must be in the future");
            }

            return null;
        }
    }
}
