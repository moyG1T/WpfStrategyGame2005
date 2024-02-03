using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    public class Warrior : Unit
    {
        public Warrior(string name, string photo, int strength, int dexterity, int intelligence, int vitality) :
            base(name, photo, strength, dexterity, intelligence, vitality)
        {
            MaxStrength = 250;
            MaxDexterity = 80;
            MaxIntelligence = 50;
            MaxVitality = 100;
        }
    }
}
