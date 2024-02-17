
using System;
using System.Collections.ObjectModel;

namespace WpfStrategyGame2005.MyClasses
{
    public class Warrior : Unit
    {
        public Warrior(string name, string photo, ObservableCollection<Weapon> weapons, int strength, int dexterity, int intelligence, int vitality, int points)
            : base(name, photo, weapons, strength, dexterity, intelligence, vitality, 250, 80, 50, 100, points)
        {
            Points = 50;
        }

        public override int Strength
        {
            get => base.Strength; set
            {
                Health = Vitality * 2 + value;
                PhysicalDamage = value;
                base.Strength = value;
            }
        }

        public override int Dexterity
        {
            get => base.Dexterity; set
            {
                Armor = value;
                CritChance = (int)(value * 0.2);
                CritDamage = (int)(value * 0.1);
                base.Dexterity = value;
            }
        }

        public override int Intelligence
        {
            get => base.Intelligence;
            set
            {
                Mana = value;
                MagicDamage = (int)(value * 0.2);
                MagicArmor = (int)(value * 0.5);
                base.Intelligence = value;
            }
        }

        public override int Vitality
        {
            get => base.Vitality; set
            {
                Health = value * 2 + Strength;
                base.Vitality = value;
            }
        }
    }
}
