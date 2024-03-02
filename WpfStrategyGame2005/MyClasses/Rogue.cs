
using System.Collections.ObjectModel;

namespace WpfStrategyGame2005.MyClasses
{
    public class Rogue : Unit
    {
        public Rogue(string name, string photo, ObservableCollection<Weapon> weapons, ObservableCollection<Chest> chests, int strength, int dexterity, int intelligence, int vitality, int points)
            : base(name, photo, weapons, chests, strength, dexterity, intelligence, vitality, 65, 250, 70, 80, points)
        {
            Points = 50;
        }

        public override int Strength
        {
            get { return base.Strength; }
            set
            {
                Health = (int)(Vitality * 2 + value * 0.5);
                PhysicalDamage = (int)(value * 0.5 + Dexterity * 0.5);
                base.Strength = value;
            }
        }

        public override int Dexterity
        {
            get { return base.Dexterity; }
            set
            {
                PhysicalDamage = (int)(value * 0.5 + Strength * 0.5);
                Armor = (int)(value * 1.5);
                CritChance = (int)(value * 0.2);
                CritDamage = (int)(value * 0.1);
                base.Dexterity = value;
            }
        }

        public override int Intelligence
        {
            get { return base.Intelligence; }
            set
            {
                Mana = (int)(value * 1.2);
                MagicDamage = (int)(value * 0.2);
                MagicArmor = (int)(value * 0.5);
                base.Intelligence = value;
            }
        }

        public override int Vitality
        {
            get { return base.Vitality; }
            set
            {
                Health = (int)(value * 1.5 + Strength);
                base.Vitality = value;
            }
        }
    }
}
