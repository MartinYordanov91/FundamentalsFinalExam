namespace _03._P_rates
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cities> cities = new();

            FillList(cities);
            OperationList(cities);
            PrintList(cities);
        }
        public static void PrintList(List<Cities> cities)
        {
            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var c in cities)
                {
                    Console.WriteLine(c);
                }
            }
        }
        public static void OperationList(List<Cities> cities)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] comandArg = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (comandArg[0] == "Plunder")
                {
                    string name = comandArg[1];
                    int people = int.Parse(comandArg[2]);
                    int gold = int.Parse(comandArg[3]);

                    if (cities.First(n => n.Name == name).People - people <= 0
                        || cities.First(n => n.Name == name).Gold - gold <= 0)
                    {
                        int curentPeople = cities.First(n => n.Name == name).People;
                        int curentGold = cities.First(n => n.Name == name).Gold;


                        if (cities.First(n => n.Name == name).People - people <= 0)
                        {
                            Console.WriteLine($"{name} plundered! {gold} gold stolen, {curentPeople} citizens killed.");
                        }
                        else if (cities.First(n => n.Name == name).Gold - gold <= 0)
                        {
                            Console.WriteLine($"{name} plundered! {curentGold} gold stolen, {people} citizens killed.");
                        }
                        cities.Remove(cities.First(n => n.Name == name));
                        Console.WriteLine($"{name} has been wiped off the map!");
                        continue;
                    }

                    cities.First(n => n.Name == name).People -= people;
                    cities.First(n => n.Name == name).Gold -= gold;

                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");


                }
                else if (comandArg[0] == "Prosper")
                {
                    string name = comandArg[1];
                    int gold = int.Parse(comandArg[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        continue;
                    }

                    cities.First(n => n.Name == name).Gold += gold;
                    int curentGold = cities.First(n => n.Name == name).Gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {curentGold} gold.");

                }
            }
        }
        public static void FillList(List<Cities> cities)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] citiInformation = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = citiInformation[0];
                int people = int.Parse(citiInformation[1]);
                int gold = int.Parse(citiInformation[2]);

                if (cities.Any(n => n.Name == name))
                {
                    cities.First(n => n.Name == name).People += people;
                    cities.First(n => n.Name == name).Gold += gold;
                }
                else
                {
                    Cities citi = new(name, people, gold);
                    cities.Add(citi);
                }
            }
        }
    }
    public class Cities
    {
        public Cities(string name, int people, int gold)
        {
            Name = name;
            People = people;
            Gold = gold;
        }

        public string Name { get; set; }

        public int People { get; set; }

        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Population: {People} citizens, Gold: {Gold} kg";
        }
    }
}