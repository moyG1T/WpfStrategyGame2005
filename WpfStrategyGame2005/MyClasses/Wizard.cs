
namespace WpfStrategyGame2005.MyClasses
{
    public class Wizard : Unit
    {
        public Wizard(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points)
            : base(name, photo, strength, dexterity, intelligence, vitality, 45, 80, 250, 70, points)
        {
            Points = 50;
        }

        public override int Strength
        {
            get { return base.Strength; }
            set
            {
                Health = (int)(Vitality * 1.4 + value * 0.2);
                PhysicalDamage = (int)(value * 0.5);
                base.Strength = value;
            }
        }

        public override int Dexterity
        {
            get => base.Dexterity;
            set => base.Dexterity = value;
        }

        public override int Intelligence
        {
            get { return base.Intelligence; }
            set
            {
                Mana = (int)(value * 1.5);
                MagicDamage = value;
                base.Intelligence = value;
            }
        }

        public override int Vitality
        {
            get { return base.Vitality; }
            set
            {
                Health = (int)(value * 1.4 + Strength * 0.2);
                base.Vitality = value;
            }
        }
    }
}
