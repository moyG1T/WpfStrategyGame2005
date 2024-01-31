﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyInterfaces
{
    public interface IHealth
    {
        int Health { get; set; }
        int MaxHealth { get; set; }

        void TakeDamage(int damage);
    }
}
