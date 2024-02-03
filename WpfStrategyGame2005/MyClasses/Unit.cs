using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    public class Unit : IHealth
    {
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _vitality;

        public string Name { get; set; }
        public string Photo { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Mana { get; set; }

        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                Health = _vitality * 2 + value;
                PhysicalDamage = value;
                _strength = value;
            }
        }
        public int MaxStrength { get; set; }

        public virtual int Dexterity
        {
            get { return _dexterity; }
            set
            {
                Armor = value;
                CritChance = (int)(value * 0.2);
                CritDamage = (int)(value * 0.1);
                _dexterity = value;
            }
        }
        public int MaxDexterity { get; set; }

        public virtual int Intelligence
        {
            get { return _intelligence; }
            set
            {
                Mana = value;
                MagicDamage = (int)(value * 0.2);
                MagicArmor = (int)(value * 0.5);
                _intelligence = value;
            }
        }
        public int MaxIntelligence { get; set; }

        public virtual int Vitality
        {
            get { return _vitality; }
            set
            {
                Health = value * 2 + _strength;
                _vitality = value;
            }
        }
        public int MaxVitality { get; set; }




        public int PhysicalDamage { get; set; }
        public int Armor { get; set; }
        public int MagicDamage { get; set; }
        public int MagicArmor { get; set; }
        public int CritChance { get; set; }
        public int CritDamage { get; set; }

        public Unit(string name, string photo, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
            Photo = photo;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Vitality = vitality;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
