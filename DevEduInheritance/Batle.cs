using System;
using System.Threading;
using DevEduInheritance.Creatures;

namespace DevEduInheritance
{
    public class Batle
    {
        public static void StartBatle<T>(T fighterOne, T fighterTwo) where T :Creature,ICombatan
        {
            Random rnd = new Random();
            while (!fighterOne.IsDie && !fighterTwo.IsDie)
            {
                Thread.Sleep(1000);
                int damageA = fighterOne.GetAttack(rnd.Next(0, 11));
                int damageB = fighterTwo.GetAttack(rnd.Next(0, 11));
                Console.WriteLine($"{fighterOne.Name} наносит {damageA} {fighterTwo.Name}");
                fighterTwo.Wounds(damageA);
                Console.WriteLine($"У {fighterTwo.Name.ToLower()} осталось {fighterTwo.Hp}\n");
                Console.WriteLine($"{fighterTwo.Name} наносит {damageB} {fighterOne.Name}");
                fighterOne.Wounds(damageB);
                Console.WriteLine($"У {fighterOne.Name.ToLower()} осталось {fighterOne.Hp}\n");
            }

            if (fighterOne.IsDie && fighterTwo.IsDie)
                Console.WriteLine("Оба умерли");
            else if (fighterTwo.IsDie)
                Console.WriteLine($"{fighterOne.Name} Победил!\n");
            else
                Console.WriteLine($"{fighterTwo.Name} Победил!\n");
        }
    }
}