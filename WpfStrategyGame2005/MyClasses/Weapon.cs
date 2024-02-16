using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyClasses
{
    public class Weapon
    {
        public string Name { get; set; }
        public WeaponType Type { get; set; }

        public int StrengthBonus { get; set; }
        public int DexterityBonus { get; set; }
        public int IntelligenceBonus { get; set; }
        public int VitalityBonus { get; set; }

        public int HealthBonus { get; set; }
        public int ManaBonus { get; set; }
        public int PhysicalDamageBonus { get; set; }
        public int ArmorBonus { get; set; }
        public int MagicDamageBonus { get; set; }
        public int MagicArmorBonus { get; set; }
        public int CritChanceBonus { get; set; }
        public int CritDamageBonus { get; set; }

        public enum WeaponType
        {
            None,
            Enchanted,
            Rare
        }

        public Weapon(string name, WeaponType type, int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus, 
            int healthBonus, int manaBonus,
            int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, int critChanceBonus, int critDamageBonus)
        {
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
    }
}
