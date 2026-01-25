namespace Methods
{
    internal class Program
    {
        // 23/11
        public static void Main()
        {
            double a, b, c, discriminant;
            double? x1, x2;
            
            Console.WriteLine("Enter coefficients:");

            SetCoefficient(out a, "a");
            SetCoefficient(out b, "b");
            SetCoefficient(out c, "c");
            
            Console.WriteLine($"Quadratic Equation: {a}x^2 + ({b})x + ({c})");

            discriminant = DiscriminantValue(a, b, c);
            Console.WriteLine($"Discriminant: {discriminant}");
            
            SetRoots(discriminant, a, b, out x1, out x2);
            if (x1 == null) Console.WriteLine("Equation does not have a root.");
            else
            {
                Console.WriteLine("Roots:");
                Console.WriteLine($"x1 = {x1.Value}");
                Console.WriteLine($"x2 = {x2.Value}");
            }
        }

        static void SetCoefficient(out double coefficientValue, string coefficientName)
        {
            Console.Write($"{coefficientName} = ");
            while (!double.TryParse(Console.ReadLine(), out coefficientValue) || (coefficientName=="a" && coefficientValue == 0))
            {
                Console.WriteLine("Invalid input! Try again.");
                Console.Write($"{coefficientName} = ");
            }
        }

        static double DiscriminantValue(double a, double b, double c)
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }

        static void SetRoots(double discriminant, double a, double b, out double? x1, out double? x2)
        {
            if (discriminant < 0)
            {
                x1 = null;
                x2 = null;
                return;
            }
            x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        }
    }
}