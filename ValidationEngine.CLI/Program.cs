using ValidationEngine.Core;
using ValidationEngine.Attributes;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write($"Appointment Date (yyyy-MM-dd) > {DateTime.Now:yyyy-MM-dd}: ");
            var dateInput = Console.ReadLine();
            DateTime.TryParse(dateInput, out var appointmentDate);

            Console.Write("Price: ");
            var priceInput = Console.ReadLine();
            decimal.TryParse(priceInput, out var price);

            var input = new UserInput
            {
                Name = name,
                AppointmentDate = appointmentDate,
                Price = price
            };

            var engine = new ValidatorEngine();
            var results = engine.Validate(input);

            if (results.Count == 0)
            {
                Console.WriteLine("Everything Is Valid");
            }
            else
            {
                Console.WriteLine("Validation Error");
                foreach (var result in results)
                {
                    Console.WriteLine($"- {result}");
                }
            }
        }
    }

    public class UserInput
    {
        [NotEmpty]
        public string Name { get; set; } = string.Empty;

        [FutureDate]
        public DateTime AppointmentDate { get; set; }

        [PositiveAmount]
        public decimal Price { get; set; }
    }
}
