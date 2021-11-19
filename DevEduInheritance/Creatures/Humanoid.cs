using System;
using DevEduInheritance.Inventors;

namespace DevEduInheritance.Creatures
{
    public class Humanoid : Creature
    {
        private Random _rnd = new();
        private bool   _racialPerk;

        public RaceType  RaceType  {get; private set;}
        public Inventory Inventory {get; set;}
        public int       Intellect {get; set;}

        public string RaceText =>
            RaceType switch
            {
                RaceType.Orc       => "Орк",
                RaceType.Undead    => "Нежить",
                RaceType.Mutant    => "Мутант",
                RaceType.Mechanism => "Механизм",
                RaceType.Human     => "Человек",
                RaceType.Elf       => "Эльф",
                RaceType.Dwarf     => "Дворф",
                RaceType.Ghost     => "Призрак",
                _                  => throw new Exception("Неизвестный тип монстра")
            };


        public override void Wounds(int damage)
        {
            if (Hp - damage < 0)
            {
                switch (RaceType)
                {
                    case RaceType.Orc when _racialPerk:
                        Hp          = 1;
                        _racialPerk = false;
                        break;
                    case RaceType.Undead when _racialPerk:
                        Hp          = MaxHp;
                        _racialPerk = false;
                        break;
                    default:
                        Hp = 0;
                        break;
                }
            }
            else
            {
                switch (RaceType)
                {
                    case RaceType.Ghost:
                    {
                        if (_rnd.Next(0, 5) != 0) //20% на промах
                            Hp -= damage;
                        break;
                    }
                    case RaceType.Elf:
                        Hp -= (int)(damage * 1.1);
                        break;
                    case RaceType.Dwarf:
                        Hp -= (int)(damage * 0.9);
                        break;
                    default:
                        Hp -= damage;
                        break;
                }
            }
        }


        public Humanoid()
        {
            Inventory = new Inventory(this);
        }
        public Humanoid(string name, RaceType raceType, int maxHp, int intellect) : this()
        {
            Name      = name;
            RaceType  = raceType;
            MaxHp     = maxHp;
            Hp        = maxHp;
            Intellect = intellect;
            if (raceType == RaceType.Undead || raceType == RaceType.Orc) //особенность рассы
                _racialPerk = true;
        }
    }
}