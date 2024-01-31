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
        private int _health;
        private int _mana;
        private int _physicalDamage;
        private int _armor;
        private int _magicDamage;
        private int _magicArmor;
        private int _critChance;
        private int _critDamage;

        public string Name { get; set; }
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
            }
        }
        public int MaxHealth { get; set; }

        public int Mana
        {
            get { return _mana; }
            set { _mana = value; }
        }




        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                _health = _vitality * 2 + value;
                _physicalDamage = value;
                _strength = value;
            }
        }
        public int MaxStrength { get; set; }

        public virtual int Dexterity
        {
            get { return _dexterity; }
            set
            {
                _armor = value;
                _critChance = (int)(value * 0.2);
                _critDamage = (int)(value * 0.1);
                _dexterity = value;
            }
        }
        public int MaxDexterity { get; set; }

        public virtual int Intelligence
        {
            get { return _intelligence; }
            set
            {
                _mana = value;
                _magicDamage = (int)(value * 0.2);
                _magicArmor = (int)(value * 0.5);
                _intelligence = value;
            }
        }
        public int MaxIntelligence { get; set; }

        public virtual int Vitality
        {
            get { return _vitality; }
            set
            {
                _health = value * 2 + _strength;
                _vitality = value;
            }
        }
        public int MaxVitality { get; set; }




        public int PhysicalDamage
        {
            get { return _physicalDamage; }
            set { _physicalDamage = value; }
        }
        public int Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        public int MagicDamage
        {
            get { return _magicDamage; }
            set { _magicDamage = value; }
        }
        public int MagicArmor
        {
            get { return _magicArmor; }
            set { _magicArmor = value; }
        }
        public int CritChance
        {
            get { return _critChance; }
            set { _critChance = value; }
        }
        public int CritDamage
        {
            get { return _critDamage; }
            set { _critDamage = value; }
        }

        public Unit(string name, int strength, int dexterity, int intelligence, int vitality)
        {
            Name = name;
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
