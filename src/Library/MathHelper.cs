namespace Library;

/// <summary>
/// Math utilities used to demonstrate number tests, Theory (parameterized) tests,
/// and edge-case scenarios.
/// </summary>
public class MathHelper
{
    public bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    public double CelsiusToFahrenheit(double celsius) => celsius * 9.0 / 5.0 + 32;
    public double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5.0 / 9.0;

    public int Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Factorial of negative numbers is undefined.");
        return n == 0 ? 1 : n * Factorial(n - 1);
    }

    public int Gcd(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    public IEnumerable<int> FibonacciSequence(int count)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
        int a = 0, b = 1;
        for (int i = 0; i < count; i++) { yield return a; (a, b) = (b, a + b); }
    }

    public bool IsEven(int n) => n % 2 == 0;
    public bool IsInRange(int value, int min, int max) => value >= min && value <= max;
}
