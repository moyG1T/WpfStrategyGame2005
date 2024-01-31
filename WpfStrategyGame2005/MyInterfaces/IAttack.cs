using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyInterfaces
{
    internal interface IAttack
    {
        int Damage { get; set; }

        void Attack(IHealth unit);
    }
}
