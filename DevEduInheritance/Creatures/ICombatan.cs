using System;

namespace DevEduInheritance.Creatures
{
    public interface ICombatan
    {
        public void Wounds(int damage);
        public int GetAttack(int bonus);
        public int MinAttack {get; set;}
        public int MaxAttack {get; set;}
    }
}