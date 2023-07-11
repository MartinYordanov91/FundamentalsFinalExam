namespace _03._Heroes_of_Code_and_Logic_VII
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Heros> heros = new();
            AddMembers(heros);
            PlayGame(heros);
            PrintHerosSurvaiv(heros);
        }
        public static void PrintHerosSurvaiv (List<Heros> heros)
        {
            foreach (var hero in heros)
            {
                Console.WriteLine(hero);
            }
        }
        public static void PlayGame(List<Heros> heros)
        {
            string comands = string.Empty;
            while ((comands = Console.ReadLine()) != "End")
            {
                string[] comandArg = comands
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string curendComand = comandArg[0];

                if (curendComand == "CastSpell")
                {
                    string heroName = comandArg[1];
                    int manaNead = int.Parse(comandArg[2]);
                    string spellName = comandArg[3];
                    if (heros.Any(n => n.Name == heroName && n.Mana >= manaNead))
                    {
                        heros.First(n => n.Name == heroName).Mana -= manaNead;
                        int manaheve = heros.First(n => n.Name == heroName).Mana;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {manaheve} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (curendComand == "TakeDamage")
                {
                    string heroName = comandArg[1];
                    int healtNead = int.Parse(comandArg[2]);
                    string atakerName = comandArg[3];

                    if (heros.Any(n => n.Name == heroName && n.Healt > healtNead))
                    {
                        heros.First(n => n.Name == heroName).Healt -= healtNead;
                        int healt = heros.First(n => n.Name == heroName).Healt;
                        Console.WriteLine($"{heroName} was hit for {healtNead} HP by {atakerName} and now has {healt} HP left!");
                    }
                    else
                    {
                        heros.Remove(heros.First(n => n.Name == heroName));
                        Console.WriteLine($"{heroName} has been killed by {atakerName}!");
                    }
                }
                else if (curendComand == "Recharge")
                {
                    string heroName = comandArg[1];
                    int manaFill = int.Parse(comandArg[2]);
                    if (heros.Any(n => n.Name == heroName && n.Mana + manaFill <= 200))
                    {
                        heros.First(n => n.Name == heroName).Mana += manaFill;
                        Console.WriteLine($"{heroName} recharged for {manaFill} MP!");
                    }
                    else
                    {
                        int manaNead = 200 - heros.First(n => n.Name == heroName).Mana;
                        heros.First(n => n.Name == heroName).Mana = 200;
                        Console.WriteLine($"{heroName} recharged for {manaNead} MP!");
                    }
                }
                else if (curendComand == "Heal")
                {
                    string heroName = comandArg[1];
                    int healtFill = int.Parse(comandArg[2]);
                    if (heros.Any(n => n.Name == heroName && n.Healt + healtFill <= 100))
                    {
                        heros.First(n => n.Name == heroName).Healt += healtFill;
                        Console.WriteLine($"{heroName} healed for {healtFill} HP!");
                    }
                    else
                    {
                        int healtNead = 100 - heros.First(n => n.Name == heroName).Healt;
                        heros.First(n => n.Name == heroName).Healt = 100;
                        Console.WriteLine($"{heroName} healed for {healtNead} HP!");
                    }
                }

            }
        }
        public static void AddMembers(List<Heros> heros)
        {
            int countPpl = int.Parse(Console.ReadLine());

            for (int i = 0; i < countPpl; i++)
            {
                string[] memberInformation = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = memberInformation[0];
                int healt = int.Parse(memberInformation[1]);
                int mana = int.Parse(memberInformation[2]);
                Heros hero = new(name, healt, mana);
                heros.Add(hero);
            }
        }
    }
    public class Heros
    {
        public Heros(string name, int healt, int mana)
        {
            Name = name;
            Healt = healt;
            Mana = mana;
        }

        public string Name { get; set; }

        public int Healt { get; set; }

        public int Mana { get; set; }


        public override string ToString()
        {
            StringBuilder outt = new();
            outt.AppendLine(Name);
            outt.AppendLine($"  HP: {Healt}");
            outt.Append($"  MP: {Mana}");
            return outt.ToString();
        }
    }
}