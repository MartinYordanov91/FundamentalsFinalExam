namespace _03._Plant_Discovery
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new();
            FillPlantsList(plants);
            ManipolatePlantsList(plants);
            PrintPlantsList(plants);

        }
        public static void PrintPlantsList(List<Plant> plants)
        {

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                Console.WriteLine(plant);
            }
        }

        public static void ManipolatePlantsList(List<Plant> plants)
        {
            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "Exhibition")
            {
                string[] comandArg = comand.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string[] plantArg = comandArg[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (plants.Any(n => n.Name == plantArg[0].Trim()) == false)
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (comandArg[0] == "Rate")
                {
                    plants.First(n => n.Name == plantArg[0].Trim()).Rating.Add(int.Parse(plantArg[1]));
                }
                else if (comandArg[0] == "Update")
                {
                    plants.First(n => n.Name == plantArg[0].Trim()).Rarity = int.Parse(plantArg[1]);
                }
                else if (comandArg[0] == "Reset")
                {
                    plants.First(n => n.Name == plantArg[0].Trim()).Rating.RemoveAll(x => x != 0);
                }
            }
        }
        public static void FillPlantsList(List<Plant> plants)
        {
            int tokens = int.Parse(Console.ReadLine());

            for (int i = 0; i < tokens; i++)
            {
                string[] plantArg = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                if (plants.Any(x => x.Name == plantArg[0].Trim()))
                {
                    plants.First(n => n.Name == plantArg[0].Trim()).Rarity = int.Parse(plantArg[1]);
                }
                else
                {
                    Plant plant = new(plantArg[0].Trim(), int.Parse(plantArg[1]));
                    plants.Add(plant);
                }

            }
        }
    }
    public class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new();
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<int> Rating = new();

        public override string ToString()
        {
            if (Rating.Sum() > 0)
            {
                return $"- {Name}; Rarity: {Rarity}; Rating: {(1.00 * Rating.Sum() / Rating.Count()):f2}";
            }
            else
            {
                return $"- {Name}; Rarity: {Rarity}; Rating: 0.00";
            }
            
        }
    }
}