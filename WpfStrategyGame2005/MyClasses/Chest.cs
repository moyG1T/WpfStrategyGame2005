using System.Collections.ObjectModel;

namespace WpfStrategyGame2005.MyClasses
{
    public class Chest : Equipment
    {
        public Chest(string name, ObservableCollection<Charity> types, int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus, int healthBonus, int manaBonus, int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, double critChanceBonus, double critDamageBonus) 
            : base(name, types, strengthBonus, dexterityBonus, intelligenceBonus, vitalityBonus, healthBonus, manaBonus, physicalDamageBonus, armorBonus, magicDamageBonus, magicArmorBonus, critChanceBonus, critDamageBonus) { }

        public int StrengthRequirement { get;set; }
        public int LevelRequirement { get;set; }
        public int VitalityRequirement { get;set; }
    }
}
