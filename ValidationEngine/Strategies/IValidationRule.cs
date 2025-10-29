using ValidationEngine.Core;

namespace ValidationEngine.Strategies
{
    public interface IValidationRule
    {
        ValidationResult? Validate(string propertyName, object value, Attribute attribute);
    }
}
