using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyClasses
{
    public class Charity
    {
        public Charity(string name, int strengthCharity, int dexterityCharity, int intelligenceCharity, int vitalityCharity,
            int healthCharity, int manaCharity, 
            int physicalDamageCharity, int armorCharity, int magicDamageCharity, int magicArmorCharity, double critChanceCharity, double critDamageCharity)
        {
            Name = name;
            StrengthCharity = strengthCharity;
            DexterityCharity = dexterityCharity;
            IntelligenceCharity = intelligenceCharity;
            VitalityCharity = vitalityCharity;
            HealthCharity = healthCharity;
            ManaCharity = manaCharity;
            PhysicalDamageCharity = physicalDamageCharity;
            ArmorCharity = armorCharity;
            MagicDamageCharity = magicDamageCharity;
            MagicArmorCharity = magicArmorCharity;
            CritChanceCharity = critChanceCharity;
            CritDamageCharity = critDamageCharity;
        }

        public string Name { get; set; }

        public int StrengthCharity { get; set; }
        public int DexterityCharity { get; set; }
        public int IntelligenceCharity { get; set; }
        public int VitalityCharity { get; set; }

        public int HealthCharity { get; set; }
        public int ManaCharity { get; set; }
        public int PhysicalDamageCharity { get; set; }
        public int ArmorCharity { get; set; }
        public int MagicDamageCharity { get; set; }
        public int MagicArmorCharity { get; set; }
        public double CritChanceCharity { get; set; }
        public double CritDamageCharity { get; set; }
    }
}
