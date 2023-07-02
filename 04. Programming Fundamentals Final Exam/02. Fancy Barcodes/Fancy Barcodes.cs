namespace _02._Fancy_Barcodes
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            int itemBarcode = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemBarcode; i++)
            {
                string testBarcode = Console.ReadLine();
                Regex tester = new(@"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+");
                Match valide = tester.Match(testBarcode);

                if (valide.Success)
                {
                    Regex digit = new(@"\d");
                    MatchCollection digitColections = digit.Matches(testBarcode);

                    if (digitColections.Any())
                    {
                        StringBuilder sb = new();
                        foreach (Match item in digitColections)
                        {
                            sb.Append(item);
                        }
                        Console.WriteLine($"Product group: {sb}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}