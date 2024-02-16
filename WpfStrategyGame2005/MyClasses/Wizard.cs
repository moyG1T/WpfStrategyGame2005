
namespace WpfStrategyGame2005.MyClasses
{
    public class Wizard : Unit
    {
        private int _strength;
        private int _intelligence;
        private int _vitality;

        public Wizard(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points)
            : base(name, photo, strength, dexterity, intelligence, vitality, 45, 80, 250, 70, points)
        {
            Points = 50;
        }

        public override int Strength
        {
            get { return _strength; }
            set
            {
                Health = (int)(Vitality * 1.4 + value * 0.2);
                PhysicalDamage = (int)(value * 0.5);
                if (value >= MaxStrength)
                    _strength = MaxStrength;
                else
                    _strength = value;
            }
        }


        public override int Intelligence
        {
            get { return _intelligence; }
            set
            {
                Mana = (int)(value * 1.5);
                MagicDamage = value;
                //MagicArmor = value;
                ////if (value >= MaxIntelligence)
                ////    _intelligence = MaxIntelligence;
                ////else
                    _intelligence = value;
            }
        }

        public override int Vitality
        {
            get { return _vitality; }
            set
            {
                Health = (int)(value * 1.4 + Strength * 0.2);
                if (value >= MaxVitality)
                    _vitality = MaxVitality;
                else
                    _vitality = value;
            }
        }
    }
}
