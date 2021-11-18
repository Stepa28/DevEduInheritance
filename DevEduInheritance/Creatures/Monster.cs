using System;

namespace DevEduInheritance.Creatures
{
   public class Monster : Creature, ICombatan
    {
        int _minAttack;
        int _maxAttack;
        string _warCry;
        string _dieCry;

        public int MinAttack
        {
            get => _minAttack;
            set
            {
                if (value <= 10 && value >= 1) _minAttack = value;
                else throw new Exception("Неверное число минимальной атаки");
            }
        }
        public int MaxAttack
        {
            get => _maxAttack;
            set
            {
                if (value <= 100 && value >= 20) _maxAttack = value;
                else throw new Exception("Неверное число максимальной атаки");
            }
        }
        public string WarCry
        {
            get => _warCry;
            set
            {
                if (value != "") _warCry = value;
                else throw new Exception("Пустой боевой клич");
            }
        }
        public string DieCry
        {
            get
            {
                return _dieCry;
            }
            set
            {
                if (value != "") _dieCry = value;
                else throw new Exception("Пустой предсмертный крик");
            }
        }

        public string GetInfo
        {
            get
            {
                return $"Имя монстра: {Name}\n" +
                       $"Текущие здоровье: {Hp}\n" +
                       $"Максимальное здоровье: {MaxHp}\n" +
                       $"Минимальная атака: {MinAttack}\n" +
                       $"Максимальная атака: {MaxAttack}\n";
            }
        }

        public Monster() { }
        public Monster(string name, int minAttack, int maxAttack, string warCry, string dieCry, int maxHp = 500)
        {
            Name = name;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
            WarCry = warCry;
            DieCry = dieCry;
            MaxHp = maxHp;
            Hp = maxHp;
        }
      

        public int GetAttack(int bonus)
        {
            Random rnd = new Random();
            return rnd.Next(MinAttack, MaxAttack + 1) + bonus;
        }
        public override void Wounds(int damage)
        {
            Hp -= damage;
        }       
        public void Heal()
        {
            Hp = MaxHp;
        }
    }
}