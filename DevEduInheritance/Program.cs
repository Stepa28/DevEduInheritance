using System;

namespace DevEduInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var gg = new Inventar();
            gg.Add(new Item("gffd",ItemType.head,100,10));
            foreach (var elem in gg)
            {
                Console.WriteLine(elem);
            }
        }
    }
}