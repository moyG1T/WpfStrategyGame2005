
namespace WpfStrategyGame2005.MyClasses
{
    public class Wizard : Unit
    {
        private int _strength;
        private int _intelligence;
        private int _vitality;

        public Wizard(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points, Weapons weapons) :
            base(name, photo, strength, dexterity, intelligence, vitality, points, weapons)
        {
            MaxStrength = 250;
            MaxDexterity = 80;
            MaxIntelligence = 50;
            MaxVitality = 100;
            Points = 50;
        }

        public override int Strength
        {
            get { return _strength; }
            set
            {
                Health = (int)(Vitality * 1.4 + value * 0.2);
                PhysicalDamage = (int)(value * 0.5);
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
                MagicArmor = value;
                _intelligence = value;
            }
        }

        public override int Vitality
        {
            get { return _vitality; }
            set
            {
                Health = (int)(value * 1.4 + Strength * 0.2);
                _vitality = value;
            }
        }
    }
}
