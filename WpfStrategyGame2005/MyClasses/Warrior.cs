
namespace WpfStrategyGame2005.MyClasses
{
    public class Warrior : Unit
    {
        public Warrior(string name, string photo, int strength, int dexterity, int intelligence, int vitality, int points)
            : base(name, photo, strength, dexterity, intelligence, vitality, 250, 80, 50, 100, points)
        {
            Points = 50;
        }
    }
}
