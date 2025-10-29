using ValidationEngine.Core;

namespace ValidationEngine.Strategies
{
    public class NotEmptyStrategy : IValidationRule
    {
        public ValidationResult? Validate(string propertyName, object value, Attribute attribute)
        {
            if (value is string str && string.IsNullOrWhiteSpace(str))
            {
                return new ValidationResult(propertyName, "Field can not be empty");
            }

            return null;
        }
    }
}
//works with [NotEmpty]