# nullable enable
namespace Projects.Utility
{
    public static class NumberFormatter
    {
        public static string FormatNumber(double number)
        {
            // Convert the double to an integer
            int integerNumber = (int)number;

            // Format the integer as a string with commas every three digits
            string formattedNumber = $"{integerNumber:n0}";

            return formattedNumber;
        }
    }
}