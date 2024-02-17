using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfStrategyGame2005.MyClasses
{
    public class Weapon : INotifyPropertyChanged
    {
        private WeaponCharity type;
        public string Name { get; set; }

        public ObservableCollection<WeaponCharity> Types { get; set; }
        public WeaponCharity Type
        {
            get { return type; }
            set
            {
                type = value;

                if (currentCharity != null)
                    ClearWeaponCharity();

                SetWeaponCharity(value);

                OnPropertyChanged("Type");
            }
        }

        private WeaponCharity currentCharity;
        public void SetWeaponCharity(WeaponCharity type)
        {
            StrengthBonus += type.StrengthCharity;
            DexterityBonus += type.DexterityCharity;
            IntelligenceBonus += type.IntelligenceCharity;
            VitalityBonus += type.VitalityCharity;

            HealthBonus += type.HealthCharity;
            ManaBonus += type.ManaCharity;

            PhysicalDamageBonus += type.PhysicalDamageCharity;
            ArmorBonus += type.ArmorCharity;
            MagicDamageBonus += type.MagicDamageCharity;
            MagicArmorBonus += type.MagicArmorCharity;
            CritChanceBonus += type.CritChanceCharity;
            CritDamageBonus += type.CritDamageCharity;

            currentCharity = type;
        }
        public void ClearWeaponCharity()
        {
            StrengthBonus -= currentCharity.StrengthCharity;
            DexterityBonus -= currentCharity.DexterityCharity;
            IntelligenceBonus -= currentCharity.IntelligenceCharity;
            VitalityBonus -= currentCharity.VitalityCharity;

            HealthBonus -= currentCharity.HealthCharity;
            ManaBonus -= currentCharity.ManaCharity;

            PhysicalDamageBonus -= currentCharity.PhysicalDamageCharity;
            ArmorBonus -= currentCharity.ArmorCharity;
            MagicDamageBonus -= currentCharity.MagicDamageCharity;
            MagicArmorBonus -= currentCharity.MagicArmorCharity;
            CritChanceBonus -= currentCharity.CritChanceCharity;
            CritDamageBonus -= currentCharity.CritDamageCharity;

            currentCharity = null;
        }

        private int strengthBonus;
        private int dexterityBonus;
        private int intelligenceBonus;
        private int vitalityBonus;
        private int healthBonus;
        private int manaBonus;
        private int physicalDamageBonus;
        private int armorBonus;
        private int magicDamageBonus;
        private int magicArmorBonus;
        private double critChanceBonus;
        private double critDamageBonus;


        public int StrengthBonus
        {
            get { return strengthBonus; }
            set { strengthBonus = value; OnPropertyChanged("StrengthBonus"); }
        }
        public int DexterityBonus
        {
            get { return dexterityBonus; }
            set { dexterityBonus = value; OnPropertyChanged("DexterityBonus"); }
        }
        public int IntelligenceBonus
        {
            get { return intelligenceBonus; }
            set { intelligenceBonus = value; OnPropertyChanged("IntelligenceBonus"); }
        }
        public int VitalityBonus
        {
            get { return vitalityBonus; }
            set { vitalityBonus = value; OnPropertyChanged("VitalityBonus"); }
        }

        public int HealthBonus
        {
            get { return healthBonus; }
            set { healthBonus = value; OnPropertyChanged("HealthBonus"); }
        }
        public int ManaBonus
        {
            get { return manaBonus; }
            set { manaBonus = value; OnPropertyChanged("ManaBonus"); }
        }
        public int PhysicalDamageBonus
        {
            get { return physicalDamageBonus; }
            set { physicalDamageBonus = value; OnPropertyChanged("PhysicalDamageBonus"); }
        }
        public int ArmorBonus
        {
            get { return armorBonus; }
            set { armorBonus = value; OnPropertyChanged("ArmorBonus"); }
        }
        public int MagicDamageBonus
        {
            get { return magicDamageBonus; }
            set { magicDamageBonus = value; OnPropertyChanged("MagicDamageBonus"); }
        }
        public int MagicArmorBonus
        {
            get { return magicArmorBonus; }
            set { magicArmorBonus = value; OnPropertyChanged("MagicArmorBonus"); }
        }
        public double CritChanceBonus
        {
            get { return critChanceBonus; }
            set { critChanceBonus = value; OnPropertyChanged("CritChanceBonus"); }
        }
        public double CritDamageBonus
        {
            get { return critDamageBonus; }
            set { critDamageBonus = value; OnPropertyChanged("CritDamageBonus"); }
        }

        public Weapon(string name, WeaponCharity type, ObservableCollection<WeaponCharity> charities, int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus,
            int healthBonus, int manaBonus,
            int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, double critChanceBonus, double critDamageBonus)
        {
            Types = charities;
            Name = name;
            Type = type;
            StrengthBonus = strengthBonus;
            DexterityBonus = dexterityBonus;
            IntelligenceBonus = intelligenceBonus;
            VitalityBonus = vitalityBonus;
            HealthBonus = healthBonus;
            ManaBonus = manaBonus;
            PhysicalDamageBonus = physicalDamageBonus;
            ArmorBonus = armorBonus;
            MagicDamageBonus = magicDamageBonus;
            MagicArmorBonus = magicArmorBonus;
            CritChanceBonus = critChanceBonus;
            CritDamageBonus = critDamageBonus;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
