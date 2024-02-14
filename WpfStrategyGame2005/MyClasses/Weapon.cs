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
        public bool IsDual { get; set; }
        public bool CanHandleShield { get; set; }

        public enum WeaponType
        {
            None,
            Enchanted,
            Rare
        }

        public Weapon(string name, WeaponType rarity, bool isDual, bool canHandleShield)
        {
            Name = name;
            Type = rarity;
            IsDual = isDual;
            CanHandleShield = canHandleShield;
        }

        public Unit EquipUnit(Unit unit, int pDamage, int health, int intel, int cChange, int cDamage)
        {

            return unit;
        }
    }
}
