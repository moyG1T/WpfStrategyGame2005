
namespace WpfStrategyGame2005.MyInterfaces
{
    public interface IHealth
    {
        int Health { get; set; }
        int MaxHealth { get; set; }

        void TakeDamage(int damage);
    }
}
