using System.Reflection;
using ValidationEngine.Attributes;
using ValidationEngine.Strategies;

namespace ValidationEngine.Core
{
    public class ValidatorEngine
    {
        //attribute type and strategy instance.
        private readonly Dictionary<Type, IValidationRule> _strategies;

        public ValidatorEngine()
        {
            //register all rules
            _strategies = new Dictionary<Type, IValidationRule>
            {
                { typeof(NotEmptyAttribute), new NotEmptyStrategy() },
                { typeof(FutureDateAttribute), new FutureDateStrategy() },
                { typeof(PositiveAmountAttribute), new PositiveAmountStrategy() }
                //add more strategies without modifying the engine (Open/Closed!)
            };
        }

        public List<ValidationResult> Validate(object target)
        {
            var results = new List<ValidationResult>();
            //Gets all properties on the object via reflection.
            var properties = target.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(target);
                //gets all metadata attributes set on the property
                var attributes = prop.GetCustomAttributes();

                foreach (var attr in attributes)
                {
                    //TryGetValue tries to retrieve a value without throwing an error if the key does not exist
                    if (_strategies.TryGetValue(attr.GetType(), out var strategy))
                    {
                        var result = strategy.Validate(prop.Name, value, attr);
                        if (result != null)
                        {
                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }
    }
}


/*
var results = properties
    .SelectMany(prop =>
    {
        var value = prop.GetValue(target);
        var attributes = prop.GetCustomAttributes();

        return attributes
            .Select(attr =>
                _strategies.TryGetValue(attr.GetType(), out var strategy)
                    ? strategy.Validate(prop.Name, value, attr)
                    : null)
            .Where(result => result != null);
    })
    .ToList();
 
 */