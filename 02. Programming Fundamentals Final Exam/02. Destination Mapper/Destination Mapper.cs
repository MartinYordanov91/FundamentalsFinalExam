namespace _02._Destination_Mapper
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex valide = new(@"(=|\/)(?<valide>[A-Z][A-Za-z]{2,})\1");
            MatchCollection matches = valide.Matches(text);
            int sum = matches.Sum(x => x.Groups["valide"].Length);
            List<string> list = new(matches.Select(x => x.Groups["valide"].Value));
            Console.WriteLine($"Destinations: {string.Join(", ", list)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}