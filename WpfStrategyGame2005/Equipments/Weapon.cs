using System.Collections.ObjectModel;
using WpfStrategyGame2005.Equipments;

namespace WpfStrategyGame2005.MyClasses
{
    public class Weapon : Equipment
    {
        public Weapon(string name, Charity type, ObservableCollection<Charity> charities,
            int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus,
            int healthBonus, int manaBonus,
            int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, double critChanceBonus, double critDamageBonus)
            :
            base(name, type, charities, strengthBonus, dexterityBonus, intelligenceBonus, vitalityBonus,
                healthBonus, manaBonus,
                physicalDamageBonus, armorBonus, magicDamageBonus, magicArmorBonus, critChanceBonus, critDamageBonus) { }
    }
}
