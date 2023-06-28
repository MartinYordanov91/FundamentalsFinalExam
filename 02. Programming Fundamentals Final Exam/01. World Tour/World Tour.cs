namespace _01._World_Tour
{
    using System;
    using System.Reflection;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var sb = new StringBuilder();
            sb.Append(text);

            while ((text = Console.ReadLine()) != "Travel")
            {
                if (text.Contains("Add"))
                {

                    var textArg = text.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    int index = int.Parse(textArg[1]);
                    var textAdd = textArg[2].Trim();
                    if ((sb.Length > index && index >= 0) == false)
                    {
                        Console.WriteLine(sb);
                        continue;
                    }
                    sb.Insert(index, textAdd);
                    Console.WriteLine(sb);
                }
                else if (text.Contains("Remove"))
                {
                    var textArg = text.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    int indexS = int.Parse(textArg[1]);
                    int indexE = int.Parse(textArg[2]);
                    if ((sb.Length > indexS
                        && indexS >= 0
                        && sb.Length > indexE
                        && indexE >= 0) == false)
                    {
                        Console.WriteLine(sb);
                        continue;
                    }
                    sb.Remove(indexS, (indexE - indexS) + 1);
                    Console.WriteLine(sb);
                }
                else if (text.Contains("Switch"))
                {
                    var textArg = text.Split(":", StringSplitOptions.RemoveEmptyEntries);
                    var textRemulve = textArg[1].Trim();
                    var textAdd = textArg[2].Trim();
                    if (sb.ToString().Contains(textRemulve) == false)
                    {
                        Console.WriteLine(sb);
                        continue;
                    }
                    sb.Replace(textRemulve, textAdd);
                    Console.WriteLine(sb);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {sb}");

        }
    }
}