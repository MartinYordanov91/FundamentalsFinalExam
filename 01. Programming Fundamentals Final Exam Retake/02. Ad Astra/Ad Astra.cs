namespace _02._Ad_Astra
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new Regex(@"(\||#)(?<name>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d{1,5})\1");
            var text = Console.ReadLine();
            var count = 0;
            var matches = reader.Matches(text);

            foreach (Match match in matches)
            {
                count += int.Parse(match.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {count/2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["name"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}