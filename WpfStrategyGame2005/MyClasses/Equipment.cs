using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfStrategyGame2005.MyClasses
{
    public class Equipment : INotifyPropertyChanged
    {
        private Charity type;
        public string Name { get; set; }
        public bool IsShield { get; set; }

        public ObservableCollection<Charity> Types { get; set; }
        public Charity Type
        {
            get { return type; }
            set
            {
                type = value;

                if (currentCharity != null)
                    ClearEquipmentCharity();

                SetEquipmentCharity(value);

                OnPropertyChanged("Type");
            }
        }

        private Charity currentCharity;
        public void SetEquipmentCharity(Charity type)
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
        public void ClearEquipmentCharity()
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

        public Equipment()
        {
        }

        public Equipment(string name,Charity type, ObservableCollection<Charity> types,  bool isShield,  int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus, int healthBonus, int manaBonus, int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, double critChanceBonus, double critDamageBonus)
        {
            Types = types;
            IsShield = isShield;
            Type = type;
            Name = name;
            CritChanceBonus = critChanceBonus;
            CritDamageBonus = critDamageBonus;
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
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
