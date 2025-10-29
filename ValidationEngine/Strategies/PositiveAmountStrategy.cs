using ValidationEngine.Core;

namespace ValidationEngine.Strategies
{
    public class PositiveAmountStrategy : IValidationRule
    {
        public ValidationResult? Validate(string propertyName, object value, Attribute attribute)
        {
            if (value is decimal amount && amount <= 0)
            {
                return new ValidationResult(propertyName, "Amount must be positive");
            }

            return null;
        }
    }
}
