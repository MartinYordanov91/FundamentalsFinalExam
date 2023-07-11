namespace _01._Activation_Keys
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string text = string.Empty;
            while ((text = Console.ReadLine())!= "Generate")
            {
                string[] comandArg = text
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string comand = comandArg[0];

                if(comand == "Contains")
                {
                    string substring = comandArg[1];
                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (comand == "Flip")
                {
                    string lowUp = comandArg[1];
                    int startIndex = int.Parse(comandArg[2]);
                    int endIndex = int.Parse(comandArg[3]);
                    StringBuilder sb = new();
                    sb.Append(key.Take(startIndex).ToArray());
                    if (lowUp == "Upper")
                    {

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb.Append(char.ToUpper(key[i]));
                        }
                    }
                    else
                    {

                        for (int i = startIndex; i < endIndex; i++)
                        {
                            sb.Append(char.ToLower(key[i]));
                        }
                    }
                    sb.Append(key.Skip(startIndex +(endIndex-startIndex)).ToArray());
                    key = sb.ToString();
                    Console.WriteLine(key);
                }
                else if (comand == "Slice")
                {
                    int startIndex = int.Parse(comandArg[1]);
                    int endIndex = int.Parse(comandArg[2]);
                    StringBuilder sb = new();
                    sb.Append(key);
                    sb.Remove(startIndex, endIndex - startIndex);
                    key = sb.ToString();
                    Console.WriteLine(key);
                }

            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}