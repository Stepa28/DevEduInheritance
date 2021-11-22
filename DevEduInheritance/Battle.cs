using System;
using System.Threading;
using DevEduInheritance.Creatures;

namespace DevEduInheritance
{
    public class Battle
    {
        public static void NewBattle<T1,T2>(T1 combatingOne, T2 combatingTwo) 
            where T1 : Creature, ICombatan
            where T2 : Creature, ICombatan
        {
            Random rnd = new();
            while (!combatingOne.IsDie && !combatingTwo.IsDie)
            {
                Thread.Sleep(1000);
                int damageA = combatingOne.GetAttack(rnd.Next(0, 11));
                int damageB = combatingTwo.GetAttack(rnd.Next(0, 11));
                Console.WriteLine($"{combatingOne.Name} наносит {damageA} {combatingTwo.Name}");
                combatingTwo.Wounds(damageA);
                Console.WriteLine($"У {combatingTwo.Name.ToLower()} осталось {combatingTwo.Hp}\n");
                Console.WriteLine($"{combatingTwo.Name} наносит {damageB} {combatingOne.Name}");
                combatingOne.Wounds(damageB);
                Console.WriteLine($"У {combatingOne.Name.ToLower()} осталось {combatingOne.Hp}\n");
            }

            if (combatingOne.IsDie && combatingTwo.IsDie) { Console.WriteLine("Оба умерли"); }
            else if (combatingTwo.IsDie)
                Console.WriteLine($"{combatingOne.Name} Победил!\n");
            else
                Console.WriteLine($"{combatingTwo.Name} Победил!\n");
        }
    }
}