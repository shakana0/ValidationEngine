
namespace ValidationEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]//[NotEmpty] only on properties
    public class NotEmptyAttribute : Attribute
    {
    }
}


// ValidatorEngine can read via reflection.