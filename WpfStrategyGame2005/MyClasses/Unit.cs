using System.Windows;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    public class Unit
    {
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _vitality;
        private Weapons _rightHand;
        private Weapons _leftHand;

        public string Name { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
        public int Exp { get; set; }

        public Weapons RightHand
        {
            get { return _rightHand; }
            set
            {
                switch (value)
                {
                    case Weapons.None:
                        break;
                    case Weapons.Stick:
                        break;
                    case Weapons.Dagger:
                        break;
                    case Weapons.Sword:
                        break;
                    case Weapons.Axe:
                        break;
                    case Weapons.Hammer:
                        break;
                }
                _rightHand = value;
            }
        }

        public Weapons LeftHand
        {
            get { return _rightHand; }
            set
            {
                if (RightHand == Weapons.Dagger)
                    _leftHand = value;

                if (LeftHand == Weapons.Shield && RightHand != Weapons.Dagger)
                    _leftHand = value;
            }
        }

        public enum Weapons
        {
            None,
            Stick,
            Dagger,
            Sword,
            Axe,
            Hammer,
            Shield
        }

        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                Health = Vitality * 2 + value;
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
                Health = value * 2 + Strength;
                _vitality = value;
            }
        }
        public int MaxVitality { get; set; }



        public int Health { get; set; }
        public int Mana { get; set; }
        public int PhysicalDamage { get; set; }
        public int Armor { get; set; }
        public int MagicDamage { get; set; }
        public int MagicArmor { get; set; }
        public int CritChance { get; set; }
        public int CritDamage { get; set; }

        public Unit(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points, Weapons weaponSlot)
        {
            Name = name;
            Photo = photo;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Vitality = vitality;
            Points = points;
            RightHand = weaponSlot;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
