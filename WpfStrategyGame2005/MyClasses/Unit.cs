using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        private int exp;
        public int Exp
        {
            get => exp;
            set
            {
                exp = value; 
                OnPropertyChanged("Exp");
                Level = Level;
            }
        }
        public int Level
        {
            get
            {
                return (int)Math.Ceiling(Math.Sqrt(Exp / 1000 * 8 + 1) / 2);
            }
            set
            {
                OnPropertyChanged("Level");
            }
        }

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

        private ObservableCollection<Weapon> allowedWeapons;
        public ObservableCollection<Weapon> AllowedWeapons
        {
            get => allowedWeapons;
            set
            {
                allowedWeapons = value;
                OnPropertyChanged("AllowedWeapons");
            }
        }

        private Weapon leftHand;
        private Weapon rightHand;

        private Weapon leftHandBackup;
        private Weapon rightHandBackup;

        public Weapon LeftHand
        {
            get { return leftHand; }
            set
            {
                if (leftHandBackup != null)
                    GetUnarmed(ref leftHandBackup);

                GetArmed(value, ref leftHandBackup);

                leftHand = value;
                OnPropertyChanged("LeftHand");
            }
        }
        public Weapon RightHand
        {
            get { return rightHand; }
            set
            {
                if (rightHandBackup != null)
                    GetUnarmed(ref rightHandBackup);

                GetArmed(value, ref rightHandBackup);

                rightHand = value;
                OnPropertyChanged("RightHand");
            }
        }

        private void GetArmed(Weapon weapon, ref Weapon handBackup)
        {
            handBackup = weapon;
            if (Strength + weapon.StrengthBonus >= MaxStrength)
            {
                handBackup.StrengthBonus = MaxStrength - Strength;
            }
            else
            {
                handBackup.StrengthBonus = weapon.StrengthBonus;
            }

            if (Dexterity + weapon.DexterityBonus >= MaxDexterity)
            {
                handBackup.DexterityBonus = MaxDexterity - Dexterity;
            }
            else
            {
                handBackup.DexterityBonus = weapon.DexterityBonus;
            }

            if (Intelligence + weapon.IntelligenceBonus >= MaxIntelligence)
            {
                handBackup.IntelligenceBonus = MaxIntelligence - Intelligence;
            }
            else
            {
                handBackup.IntelligenceBonus = weapon.IntelligenceBonus;
            }

            if (Vitality + weapon.VitalityBonus >= MaxVitality)
            {
                handBackup.VitalityBonus = MaxVitality - Vitality;
            }
            else
            {
                handBackup.VitalityBonus = weapon.VitalityBonus;
            }

            Strength += weapon.StrengthBonus;
            Dexterity += weapon.DexterityBonus;
            Intelligence += weapon.IntelligenceBonus;
            Vitality += weapon.VitalityBonus;

            Health += weapon.HealthBonus;
            Mana += weapon.ManaBonus;

            PhysicalDamage += weapon.PhysicalDamageBonus; // <- сложение не идет
            Armor += weapon.ArmorBonus;
            MagicDamage += weapon.MagicDamageBonus;
            MagicArmor += weapon.MagicArmorBonus;
            CritChance = (int)(CritChance * weapon.CritChanceBonus);
            CritDamage = (int)(CritDamage * weapon.CritDamageBonus);
        }

        private void GetUnarmed(ref Weapon handBackup)
        {
            Strength -= handBackup.StrengthBonus;
            Dexterity -= handBackup.DexterityBonus;
            Intelligence -= handBackup.IntelligenceBonus;
            Vitality -= handBackup.VitalityBonus;

            Health -= handBackup.HealthBonus;
            Mana -= handBackup.ManaBonus;

            PhysicalDamage -= handBackup.PhysicalDamageBonus;
            Armor -= handBackup.ArmorBonus;
            MagicDamage -= handBackup.MagicDamageBonus;
            MagicArmor -= handBackup.MagicArmorBonus;
            CritChance = (int)(CritChance / handBackup.CritChanceBonus);
            CritDamage = (int)(CritDamage / handBackup.CritDamageBonus);

            handBackup = null;
        }

        private int health;
        private int mana;
        private int physicalDamage;
        private int armor;
        private int magicDamage;
        private int magicArmor;
        private int critChance;
        private int critDamage;

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


        public Unit(string name, string photo, ObservableCollection<Weapon> weapons, int strength, int dexterity, int intelligence, int vitality, int maxStrength, int maxDexterity, int maxIntelligence, int maxVitality, int points)
        {
            Name = name;
            Photo = photo;
            AllowedWeapons = weapons;

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
