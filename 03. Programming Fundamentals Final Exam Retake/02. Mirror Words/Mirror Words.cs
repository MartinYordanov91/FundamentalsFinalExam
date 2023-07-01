namespace _02._Mirror_Words
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            Regex wordArg = new(@"(@|#)(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1");
            string text = Console.ReadLine();
            Match match = wordArg.Match(text);
            MatchCollection matches = wordArg.Matches(text);

            if (match.Success == false)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                List<string> mirror = new();

                foreach (Match mat in matches)
                {
                    StringBuilder sb = new();
                    for (int i = mat.Groups["second"].Value.Length -1; i >= 0; i--)
                    {
                        sb.Append(mat.Groups["second"].Value[i]);
                    }
                    
                    if (mat.Groups["first"].Value == sb.ToString())
                    {
                        mirror.Add(mat.Groups["first"].Value + " <=> " + mat.Groups["second"].Value);
                    }
                }

                if (mirror.Count > 0)
                {
                    Console.WriteLine($"The mirror words are:");
                    Console.WriteLine($"{string.Join(", ",mirror)}");
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
        }
    }
}