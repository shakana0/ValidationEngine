namespace ValidationEngine.Core
{
    public class ValidationResult
    {
        public string PropertyName { get; }
        public string Message { get; }

        public ValidationResult(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public override string ToString()
        {
            return $"{PropertyName}: {Message}";
        }
    }
}
//Tells where the error happened and why
