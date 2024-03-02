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
    public class Weapon : Equipment
    {
        public Weapon( string name, ObservableCollection<Charity> types, bool isShield, int strengthBonus, int dexterityBonus, int intelligenceBonus, int vitalityBonus, int healthBonus, int manaBonus, int physicalDamageBonus, int armorBonus, int magicDamageBonus, int magicArmorBonus, double critChanceBonus, double critDamageBonus) 
            : base( name, types, strengthBonus, dexterityBonus, intelligenceBonus, vitalityBonus, healthBonus, manaBonus, physicalDamageBonus, armorBonus, magicDamageBonus, magicArmorBonus, critChanceBonus, critDamageBonus)
        {
            IsShield = isShield;
        }
        public bool IsShield { get; set; }
    }
}
