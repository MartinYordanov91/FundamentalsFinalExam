namespace _03._Need_for_Speed_III
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Viechel> viechels = new();
            RegisterViechels(viechels);

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "Stop")
            {
                string[] comandArg = comand
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = comandArg[0];

                if (action == "Drive")
                {
                    DriveCar(viechels, comandArg);
                }
                else if (action == "Refuel")
                {
                    RefuelCar(viechels, comandArg);
                }
                else if (action == "Revert")
                {
                    ReverCar(viechels, comandArg);
                }
            }
            PrintViechel(viechels);
        }
        public static void PrintViechel(List<Viechel> viechels)
        {
            foreach (var item in viechels)
            {
                Console.WriteLine(item);
            }
        }
        public static void ReverCar(List<Viechel> viechels, string[] comandArg)
        {
            string car = comandArg[1];
            int mileage = int.Parse(comandArg[2]);
            viechels.First(c => c.Car == car).MileAge -= mileage;

            if(viechels.First(c => c.Car == car).MileAge > 10000)
            {
                Console.WriteLine($"{car} mileage decreased by {mileage} kilometers");
            }
            else
            {
                viechels.First(c => c.Car == car).MileAge = 10000;
            }

        }
        public static void RefuelCar(List<Viechel> viechels, string[] comandArg)
        {
            string car = comandArg[1];
            int fuel = int.Parse(comandArg[2]);

            if (viechels.First(c => c.Car == car).Fuel + fuel <= 75)
            {
                viechels.First(c => c.Car == car).Fuel += fuel;
                Console.WriteLine($"{car} refueled with {fuel} liters");
            }
            else
            {
                int fuelnead = 75 - viechels.First(c => c.Car == car).Fuel;
                viechels.First(c => c.Car == car).Fuel = 75;
                Console.WriteLine($"{car} refueled with {fuelnead} liters");
            }

        }
        public static void DriveCar(List<Viechel> viechels, string[] comandArg)
        {
            string car = comandArg[1];
            int distance = int.Parse(comandArg[2]);
            int fuelNead = int.Parse(comandArg[3]);

            if (viechels.First(c => c.Car == car).Fuel < fuelNead)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            viechels.First(c => c.Car == car).Fuel -= fuelNead;
            viechels.First(c => c.Car == car).MileAge += distance;
            Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNead} liters of fuel consumed.");

            if (viechels.First(c => c.Car == car).MileAge >= 100_000)
            {
                viechels.Remove(viechels.First(c => c.Car == car));
                Console.WriteLine($"Time to sell the {car}!");
            }

        }
        public static void RegisterViechels(List<Viechel> viechels)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] viechelArg = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = viechelArg[0];
                int mileAge = int.Parse(viechelArg[1]);
                int fuel = int.Parse(viechelArg[2]);

                Viechel viechel = new(car, mileAge, fuel);
                viechels.Add(viechel);
            }
        }
    }
    public class Viechel
    {
        public Viechel(string car, int mileAge, int fuel)
        {
            Car = car;
            MileAge = mileAge;
            Fuel = fuel;
        }

        public string Car { get; set; }

        public int MileAge { get; set; }

        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Car} -> Mileage: {MileAge} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
}