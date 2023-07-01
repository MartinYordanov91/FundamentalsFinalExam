namespace _01._Secret_Chat
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string ahead = Console.ReadLine();
            string comands = string.Empty;

            while ((comands = Console.ReadLine()) != "Reveal")
            {
                string[] comandArg = comands.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                if(comands == string.Empty) { continue; }

                if (comandArg[0] == "InsertSpace")
                {
                    ahead = InsertSpaceAhead(comandArg, ahead);

                }
                else if (comandArg[0] == "Reverse")
                {
                    ahead = ReverseAhead(comandArg, ahead);
                }
                else if (comandArg[0] == "ChangeAll")
                {
                    ahead = ChangeAllAhead(comandArg, ahead);
                }

            }
            Console.WriteLine($"You have a new text message: {ahead}");
        }
        public static string ChangeAllAhead(string[] comandArg, string ahead)
        {
            StringBuilder sb = new();
            sb.Append(ahead);
            string textOld = comandArg[1];
            string textNew = comandArg[2];
            sb.Replace(textOld, textNew);

            Console.WriteLine(sb);
            return sb.ToString();
        }
        public static string ReverseAhead(string[] comandArg, string ahead)
        {
            StringBuilder sb = new();
            sb.Append(ahead);
            string text = comandArg[1];
            if (ahead.Contains(text))
            {
                int index = sb.ToString().IndexOf(text);
                int lengt = text.Length;
                sb.Remove(index, lengt);
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    sb.Append(text[i]);
                }

                Console.WriteLine(sb);
                return sb.ToString();
            }
            else
            {
                Console.WriteLine("error");
                return sb.ToString();
            }

            
        }
        public static string InsertSpaceAhead(string[] comandArg, string ahead)
        {
            StringBuilder sb = new();
            sb.Append(ahead);
            int index = int.Parse(comandArg[1]);
            sb.Insert(index, ' ');
            Console.WriteLine(sb);
            return sb.ToString();
        }
    }
}