using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAD2
{
    class Chance<T>
    {
        T value;
        double chance;

        public Chance(T value, double chance)
        {
            this.value = value;
            this.chance = chance;
        }
    }
}
