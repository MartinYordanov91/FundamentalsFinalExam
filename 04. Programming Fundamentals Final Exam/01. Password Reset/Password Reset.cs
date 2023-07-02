namespace _01._Password_Reset
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();

            string comandInfo = string.Empty;
            while ((comandInfo = Console.ReadLine()) != "Done")
            {
                string[] comandArg = comandInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string comand = comandArg[0];

                if (comand == "TakeOdd")
                {
                    passwordInput = TakeOddPass(passwordInput);
                }
                else if (comand == "Cut")
                {
                    passwordInput = CutPass(passwordInput, comandArg);
                }
                else if (comand == "Substitute")
                {
                    passwordInput = SubstitutePass(passwordInput, comandArg);
                }
            }
            Console.WriteLine($"Your password is: {passwordInput}");
        }
        public static string SubstitutePass(string passwordInput, string[] comandArg)
        {
            StringBuilder sb = new();
            sb.Append(passwordInput);
            string substring = comandArg[1];
            string substitute = comandArg[2];
            if (passwordInput.Contains(substring))
            {
                sb.Replace(substring , substitute);
                Console.WriteLine(sb);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            
            return sb.ToString();
        }
        public static string CutPass(string passwordInput, string[] comandArg)
        {
            StringBuilder sb = new();
            sb.Append(passwordInput);
            int index = int.Parse(comandArg[1]);
            int lenght= int.Parse(comandArg[2]);
            sb.Remove(index, lenght);
            Console.WriteLine(sb);
            return sb.ToString();
        }
        public static string TakeOddPass(string passwordInput)
        {
            StringBuilder sb = new();
            for (int i = 0; i < passwordInput.Length; i++)
            {
                if (i % 2 == 1)
                {
                    sb.Append(passwordInput[i]);
                }
            }
            Console.WriteLine(sb);
            return sb.ToString();
        }

    }
}