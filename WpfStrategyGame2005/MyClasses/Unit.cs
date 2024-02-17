using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    public class Unit : INotifyPropertyChanged
    {
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _vitality;

        public string Name { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
        public int Exp { get; set; }

        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= MaxStrength)
                    _strength = MaxStrength;
                else
                    _strength = value;
                OnPropertyChanged("Strength");
            }
        }
        private int maxStrength;
        public int MaxStrength { get => maxStrength; }

        public virtual int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value >= MaxDexterity)
                    _dexterity = MaxDexterity;
                else
                    _dexterity = value;
                OnPropertyChanged("Dexterity");
            }
        }
        private int maxDexterity;
        public int MaxDexterity { get => maxDexterity; }

        public virtual int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (value >= MaxIntelligence)
                    _intelligence = MaxIntelligence;
                else
                    _intelligence = value;
                OnPropertyChanged("Intelligence");
            }
        }
        private int maxIntelligence;
        public int MaxIntelligence { get => maxIntelligence; }

        public virtual int Vitality
        {
            get { return _vitality; }
            set
            {
                if (value >= MaxVitality)
                    _vitality = MaxVitality;
                else
                    _vitality = value;
                OnPropertyChanged("Vitality");
            }
        }
        private int maxVitality;
        public int MaxVitality { get => maxVitality; }


        private Weapon leftHand;
        private Weapon rightHand;

        public Weapon LeftHand
        {
            get { return leftHand; }
            set
            {
                leftHand = value;
                OnPropertyChanged("LeftHand");
            }
        }
        public Weapon RightHand
        {
            get { return rightHand; }
            set
            {
                rightHand = value;
                if (equippedWeapon != null)
                    GetUnarmed();
                GetArmed(value);
                OnPropertyChanged("RightHand");
            }
        }

        private Weapon equippedWeapon;

        private void GetArmed(Weapon weapon)
        {
            int _dexterity;
            if (weapon.StrengthBonus + Strength > MaxStrength)
            {
                weapon.StrengthBonus = weapon.StrengthBonus + Strength - MaxStrength;
            }
            else if (weapon.DexterityBonus + Dexterity > MaxDexterity)
            {
                _dexterity = weapon.DexterityBonus + Dexterity - MaxDexterity;
                Dexterity += weapon.DexterityBonus;
                weapon.DexterityBonus = _dexterity;
            }
            Strength += weapon.StrengthBonus;
            Dexterity += weapon.DexterityBonus;
            Intelligence += weapon.IntelligenceBonus;
            Vitality += weapon.VitalityBonus;

            Health += weapon.HealthBonus;
            Mana += weapon.ManaBonus;

            PhysicalDamage += weapon.PhysicalDamageBonus;
            Armor += weapon.ArmorBonus;
            MagicDamage += weapon.MagicDamageBonus;
            MagicArmor += weapon.MagicArmorBonus;
            CritChance = (int)(CritChance * weapon.CritChanceBonus);
            CritDamage = (int)(CritDamage * weapon.CritDamageBonus);

            equippedWeapon = weapon;
        }

        private void GetUnarmed()
        {
            Strength -= equippedWeapon.StrengthBonus;
            Dexterity -= equippedWeapon.DexterityBonus;
            Intelligence -= equippedWeapon.IntelligenceBonus;
            Vitality -= equippedWeapon.VitalityBonus;

            Health -= equippedWeapon.HealthBonus;
            Mana -= equippedWeapon.ManaBonus;

            PhysicalDamage -= equippedWeapon.PhysicalDamageBonus;
            Armor -= equippedWeapon.ArmorBonus;
            MagicDamage -= equippedWeapon.MagicDamageBonus;
            MagicArmor -= equippedWeapon.MagicArmorBonus;
            CritChance = (int)(CritChance / equippedWeapon.CritChanceBonus);
            CritDamage = (int)(CritDamage / equippedWeapon.CritDamageBonus);

            equippedWeapon = null;
        }

        public int health;
        public int mana;
        public int physicalDamage;
        public int armor;
        public int magicDamage;
        public int magicArmor;
        public int critChance;
        public int critDamage;

        public int Health
        {
            get { return health; }
            set { health = value; OnPropertyChanged("Health"); }
        }
        public int Mana
        {
            get { return mana; }
            set { mana = value; OnPropertyChanged("Mana"); }
        }
        public int PhysicalDamage
        {
            get { return physicalDamage; }
            set { physicalDamage = value; OnPropertyChanged("PhysicalDamage"); }
        }
        public int Armor
        {
            get { return armor; }
            set { armor = value; OnPropertyChanged("Armor"); }
        }
        public int MagicDamage
        {
            get { return magicDamage; }
            set { magicDamage = value; OnPropertyChanged("MagicDamage"); }
        }
        public int MagicArmor
        {
            get { return magicArmor; }
            set { magicArmor = value; OnPropertyChanged("MagicArmor"); }
        }
        public int CritChance
        {
            get { return critChance; }
            set { critChance = value; OnPropertyChanged("CritChance"); }
        }
        public int CritDamage
        {
            get { return critDamage; }
            set { critDamage = value; OnPropertyChanged("CritDamage"); }
        }


        public Unit(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int maxStrength, int maxDexterity, int maxIntelligence, int maxVitality, int points)
        {
            Name = name;
            Photo = photo;

            this.maxStrength = maxStrength;
            this.maxDexterity = maxDexterity;
            this.maxIntelligence = maxIntelligence;
            this.maxVitality = maxVitality;

            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Vitality = vitality;
            Points = points;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
