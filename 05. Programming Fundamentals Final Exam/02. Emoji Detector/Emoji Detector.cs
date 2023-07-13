namespace _02._Emoji_Detector
{
    using System;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            List<string> allEmojis = new();
            Dictionary<string, int> emojis = new();
            Regex digit = new(@"\d");
            Regex emoji = new(@"(:{2}|\*{2})[A-Z][a-z]{2,}\1");
            MatchCollection digitMatchCollection = digit.Matches(textInput);
            MatchCollection emojiMatchCollection = emoji.Matches(textInput);
            int coolLevel = 1;

            foreach (Match match in digitMatchCollection)
            {
                coolLevel *= int.Parse(match.Value);
            }

            foreach (Match em in emojiMatchCollection)
            {
                string curentEmoji = em.ToString();
                allEmojis.Add(curentEmoji );
            }

            foreach (var item in allEmojis)
            {
                int values = 0;

                foreach (var tem in item)
                {
                    if (char.IsLetter(tem))
                    {
                        values += tem;
                    }
                }
                emojis.Add(item, values);
            }

            Console.WriteLine($"Cool threshold: {coolLevel}");
            Console.WriteLine($"{allEmojis.Count} emojis found in the text. The cool ones are:");
            foreach (var item in emojis)
            {
                if(item.Value > coolLevel)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}  