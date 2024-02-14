
namespace WpfStrategyGame2005.MyClasses
{
    public class Warrior : Unit
    {
        public Warrior(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points) :
            base(name, photo, strength, dexterity, intelligence, vitality, points)
        {
            MaxStrength = 250;
            MaxDexterity = 80;
            MaxIntelligence = 50;
            MaxVitality = 100;
            Points = 50;
        }
    }
}
