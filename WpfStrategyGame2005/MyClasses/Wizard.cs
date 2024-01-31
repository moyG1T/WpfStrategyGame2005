using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyClasses
{
    internal class Wizard : Unit
    {
        public Wizard(string name, int strength, int dexterity, int intelligence, int vitality) : 
            base(name, strength, dexterity, intelligence, vitality)
        {
            MaxStrength = 45;
            MaxDexterity = 80;
            MaxIntelligence = 250;
            MaxVitality = 70;
        }
    }
}
