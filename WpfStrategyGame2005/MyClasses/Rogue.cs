using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    internal class Rogue : Unit
    {
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _vitality;
        public Rogue(string name, string photo, int strength, int dexterity, int intelligence, int vitality) :
            base(name, photo, strength, dexterity, intelligence, vitality)
        {
            MaxStrength = 65;
            MaxDexterity = 250;
            MaxIntelligence = 70;
            MaxVitality = 80;
        }

        public override int Strength
        {
            get { return _strength; }
            set
            {
                Health = (int)(Vitality * 2 + value * 0.5);
                PhysicalDamage = (int)(value * 0.5 + Dexterity * 0.5);
                _strength = value;
            }
        }

        public override int Dexterity
        {
            get { return _dexterity; }
            set
            {
                PhysicalDamage = (int)(value * 0.5 + Strength * 0.5);
                Armor = (int)(value * 1.5);
                CritChance = (int)(value * 0.2);
                CritDamage = (int)(value * 0.1);
                _dexterity = value;
            }
        }

        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                Mana = (int)(value * 1.2);
                MagicDamage = (int)(value * 0.2);
                MagicArmor = (int)(value * 0.5);
                _intelligence = value;
            }
        }

        public override int Vitality
        {
            get { return _vitality; }
            set
            {
                Health = (int)(value * 1.5 + Strength);
                _vitality = value;
            }
        }
    }
}
