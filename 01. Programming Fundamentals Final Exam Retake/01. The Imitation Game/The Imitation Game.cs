namespace _01._The_Imitation_Game
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string textInput = Console.ReadLine();
            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "Decode")
            {
                var comandArg = comand
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (comandArg[0] == "Move")
                {
                    int muve = int.Parse(comandArg[1]);
                    textInput = MoveCharakters(textInput, muve);

                }
                else if (comandArg[0] == "Insert")
                {
                    int index = int.Parse(comandArg[1]);
                    string text = comandArg[2];
                    textInput = InsertCharakters(textInput, text, index);
                    
                }
                else if (comandArg[0] == "ChangeAll")
                {
                    string substring = comandArg[1];
                    string replaysmant = comandArg[2];
                    textInput = ChangeAllCharakters(textInput, substring, replaysmant);
                }

            }
            Console.WriteLine($"The decrypted message is: {textInput}");
        }

        public static string ChangeAllCharakters(string textinput, string substring, string replaysmantt)
        {
            var a = new StringBuilder();
            a.Append(textinput);
            a.Replace(substring , replaysmantt);

            return a.ToString();
        }
        public static string InsertCharakters(string textinput, string text, int index)
        {
            var a = new StringBuilder();

            a.Append(textinput.Take(index).ToArray());
            a.Append(text);
            a.Append(textinput.Skip(index).ToArray());

            return a.ToString();
        }
        public static string MoveCharakters(string text, int move)
        {
            //if (move > text.Length)
            //{
            //    move %= text.Length;
            //}
            
            var a = new StringBuilder();
            a.Append(text.Skip(move).ToArray());
            a.Append(text.Take(move).ToArray());

            return a.ToString();
        }
    }
}