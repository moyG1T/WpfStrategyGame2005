using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyClasses
{
    internal class Rogue : Unit
    {
        public Rogue(string name, int strength, int dexterity, int intelligence, int vitality) :
            base(name, strength, dexterity, intelligence, vitality)
        {
            MaxStrength = 65;
            MaxDexterity = 250;
            MaxIntelligence = 70;
            MaxVitality = 80;
        }
    }
}
