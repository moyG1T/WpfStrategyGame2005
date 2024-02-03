

namespace WpfStrategyGame2005.MyInterfaces
{
    internal interface IAttack
    {
        int Damage { get; set; }

        void Attack(IHealth unit);
    }
}
