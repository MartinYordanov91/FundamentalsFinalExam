namespace _03._The_Pianist
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            var colectionsPiece = new List<PianoKey>();
            FillColections(colectionsPiece);
            OperationColections(colectionsPiece);
            PrintColections(colectionsPiece);
        }
        public static void PrintColections(List<PianoKey> colectionsPiece)
        {
            foreach (var piece in colectionsPiece)
            {
                Console.WriteLine(piece);
            }
        }
        public static void OperationColections(List<PianoKey> colectionsPiece)
        {
            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "Stop")
            {
                var comandArg = comand.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (comandArg[0] == "Add")
                {
                    ComandAddColections(colectionsPiece, comand);
                }
                else if (comandArg[0] == "Remove")
                {
                    ComandRemoveColections(colectionsPiece, comand);
                }
                else if (comandArg[0] == "ChangeKey")
                {
                    ComandChangeKeyColections(colectionsPiece, comand);
                }
            }
        }
        public static void ComandChangeKeyColections(List<PianoKey> colectionsPiece, string comand)
        {
            string[] pieceArg = comand
                   .Split("|", StringSplitOptions.RemoveEmptyEntries);

            if (colectionsPiece.Any(p => p.Piece == pieceArg[1]))
            {
                colectionsPiece.First(p => p.Piece == pieceArg[1]).Key = pieceArg[2];
                Console.WriteLine($"Changed the key of {pieceArg[1]} to {pieceArg[2]}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceArg[1]} does not exist in the collection.");
            }
        }

        public static void ComandRemoveColections(List<PianoKey> colectionsPiece, string comand)
        {
            string[] pieceArg = comand
                   .Split("|", StringSplitOptions.RemoveEmptyEntries);
            
            if (colectionsPiece.Any(p => p.Piece == pieceArg[1]))
            {
                colectionsPiece.Remove(colectionsPiece.First(p => p.Piece == pieceArg[1]));
                Console.WriteLine($"Successfully removed {pieceArg[1]}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {pieceArg[1]} does not exist in the collection.");
            }

        }
        public static void ComandAddColections(List<PianoKey> colectionsPiece ,string comand)
        {
            string[] pieceArg = comand
                   .Split("|", StringSplitOptions.RemoveEmptyEntries);
            var piece = new PianoKey(pieceArg[1], pieceArg[2], pieceArg[3]);

            if (colectionsPiece.Any(p=>p.Piece == pieceArg[1]))
            {
                Console.WriteLine($"{pieceArg[1]} is already in the collection!");
                
            }
            else
            {
                colectionsPiece.Add(piece);
                Console.WriteLine($"{pieceArg[1]} by {pieceArg[2]} in {pieceArg[3]} added to the collection!");
            }
           
        }
        public static void FillColections(List<PianoKey> colectionsPiece)
        {
            int colectionLengt = int.Parse(Console.ReadLine());

            for (int i = 0; i < colectionLengt; i++)
            {
                string[] pieceArg = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                var piece = new PianoKey(pieceArg[0], pieceArg[1], pieceArg[2]);
                
                colectionsPiece.Add(piece);

            }
        }
    }

    public class PianoKey
    {
        public PianoKey(string piece, string composer, string key)
        {
            Piece = piece;
            Composer = composer;
            Key = key;
        }

        public string Piece { get; set; }

        public string Composer { get; set; }

        public string Key { get; set; }

        public override string ToString()
        {
            return$"{Piece} -> Composer: {Composer}, Key: {Key}";
        }
    }
}