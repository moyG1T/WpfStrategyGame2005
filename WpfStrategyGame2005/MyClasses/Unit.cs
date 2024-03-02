using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Linq;
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
        private string level;
        public string Level
        {
            get
            {
                if (level == null)
                    level = $"Лвл 1 - ({Exp}/1000)";
                return level;
            }
            set
            {
                if (Exp < 1000)
                    level = $"Лвл 1 - ({Exp}/1000)";
                else if (Exp >= 1000 && Exp < 3000)
                    level = $"Лвл 2 - ({Exp - 1000}/2000)";
                else if (Exp >= 3000 && Exp < 6000)
                    level = $"Лвл 3 - ({Exp - 3000}/3000)";
                else if (Exp >= 6000 && Exp < 10000)
                    level = $"Лвл 4 - ({Exp - 6000}/4000)";
                else if (Exp >= 10000 && Exp < 15000)
                    level = $"Лвл 5 - ({Exp - 10000}/5000)";
                else if (Exp >= 15000 && Exp < 21000)
                    level = $"Лвл 6 - ({Exp - 15000}/6000)";
                else if (Exp >= 21000 && Exp < 28000)
                    level = $"Лвл 7 - ({Exp - 21000}/7000)";
                else if (Exp >= 28000 && Exp < 36000)
                    level = $"Лвл 8 - ({Exp - 28000}/8000)";
                else if (Exp >= 36000 && Exp < 45000)
                    level = $"Лвл 9 - ({Exp - 36000}/9000)";
                else if (Exp >= 45000)
                    level = $"Лвл 10 - ({Exp - 45000})";
                OnPropertyChanged("Level");
            }
        }

        public bool ShieldSlot { get; set; }

        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                if (value >= MaxStrength)
                    _strength = MaxStrength;
                else if (value <= 1)
                    _strength = 1;
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
                else if (value <= 1)
                    _dexterity = 1;
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
                else if (value <= 1)
                    _intelligence = 1;
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
                else if (value <= 1)
                    _vitality = 1;
                else
                    _vitality = value;
                OnPropertyChanged("Vitality");
            }
        }
        private int maxVitality;
        public int MaxVitality { get => maxVitality; }

        private IEnumerable<Weapon> leftHandWeapons;
        public IEnumerable<Weapon> LeftHandWeapons
        {
            get => leftHandWeapons;
            set
            {
                leftHandWeapons = value;
                OnPropertyChanged("LeftHandWeapons");
            }
        }
        public ObservableCollection<Weapon> RightHandWeapons { get; set; }
        public ObservableCollection<Chest> Chests { get; set; }

        private Weapon leftHand;
        private Weapon rightHand;

        private Equipment weaponBackup;
        private Equipment chestBackup;

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
            get { return rightHand == null ? RightHandWeapons[0] : rightHand; }
            set
            {
                if (weaponBackup != null)
                    GetUnarmed(ref weaponBackup);

                GetArmed(value, ref weaponBackup);

                if (value.IsShield)
                {
                    LeftHandWeapons = RightHandWeapons.Where(x => x.Name == "Щит");
                }
                else
                {
                    LeftHandWeapons = new ObservableCollection<Weapon>();
                }

                rightHand = value;
                OnPropertyChanged("RightHand");
            }
        }

        private Chest chest;
        public Chest Chest
        {
            get => chest == null ? Chests[0] : chest;
            set
            {
                if (chestBackup != null)
                    GetUnarmed(ref chestBackup);

                GetArmed(value, ref chestBackup);

                chest = value;
                OnPropertyChanged("Chest");
            }
        }

        private void GetArmed(Equipment equipment, ref Equipment backup)
        {
            backup = equipment;
            if (Strength + equipment.StrengthBonus >= MaxStrength)
            {
                backup.StrengthBonus = MaxStrength - Strength;
            }
            else if (Strength + equipment.StrengthBonus <= 1)
            {
                backup.StrengthBonus = -(Strength - 1);
            }
            else
            {
                backup.StrengthBonus = equipment.StrengthBonus;
            }

            if (Dexterity + equipment.DexterityBonus >= MaxDexterity)
            {
                backup.DexterityBonus = MaxDexterity - Dexterity;
            }
            else if (Dexterity + equipment.DexterityBonus <= 1)
            {
                backup.DexterityBonus = -(Dexterity - 1);
            }
            else
            {
                backup.DexterityBonus = equipment.DexterityBonus;
            }

            if (Intelligence + equipment.IntelligenceBonus >= MaxIntelligence)
            {
                backup.IntelligenceBonus = MaxIntelligence - Intelligence;
            }
            else if (Intelligence + equipment.IntelligenceBonus <= 1)
            {
                backup.IntelligenceBonus = -(Intelligence - 1);
            }
            else
            {
                backup.IntelligenceBonus = equipment.IntelligenceBonus;
            }

            if (Vitality + equipment.VitalityBonus >= MaxVitality)
            {
                backup.VitalityBonus = MaxVitality - Vitality;
            }
            else if (Vitality + equipment.VitalityBonus <= 1)
            {
                backup.VitalityBonus = -(Vitality - 1);
            }
            else
            {
                backup.VitalityBonus = equipment.VitalityBonus;
            }

            Strength += equipment.StrengthBonus;
            Dexterity += equipment.DexterityBonus;
            Intelligence += equipment.IntelligenceBonus;
            Vitality += equipment.VitalityBonus;

            Health += equipment.HealthBonus;
            Mana += equipment.ManaBonus;

            PhysicalDamage += equipment.PhysicalDamageBonus; // <- сложение не идет
            Armor += equipment.ArmorBonus;
            MagicDamage += equipment.MagicDamageBonus;
            MagicArmor += equipment.MagicArmorBonus;
            CritChance = (int)(CritChance * equipment.CritChanceBonus);
            CritDamage = (int)(CritDamage * equipment.CritDamageBonus);
        }

        private void GetUnarmed(ref Equipment backup)
        {
            Strength -= backup.StrengthBonus;
            Dexterity -= backup.DexterityBonus;
            Intelligence -= backup.IntelligenceBonus;
            Vitality -= backup.VitalityBonus;

            Health -= backup.HealthBonus;
            Mana -= backup.ManaBonus;

            PhysicalDamage -= backup.PhysicalDamageBonus;
            Armor -= backup.ArmorBonus;
            MagicDamage -= backup.MagicDamageBonus;
            MagicArmor -= backup.MagicArmorBonus;
            CritChance = (int)(CritChance / backup.CritChanceBonus);
            CritDamage = (int)(CritDamage / backup.CritDamageBonus);

            backup = null;
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


        public Unit(string name, string photo, ObservableCollection<Weapon> weapons, ObservableCollection<Chest> chests, int strength, int dexterity, int intelligence, int vitality, int maxStrength, int maxDexterity, int maxIntelligence, int maxVitality, int points)
        {
            Name = name;
            Photo = photo;

            LeftHandWeapons = weapons.Where(x => x.Name == "Щит");
            RightHandWeapons = weapons;
            Chests = chests;

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

        public Unit(string name, string photo, ObservableCollection<Weapon> weapons, int strength, int dexterity, int intelligence, int vitality, int v1, int v2, int v3, int v4, int points)
        {
            Name = name;
            Photo = photo;
            RightHandWeapons = weapons;
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
