using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class ShieldGenerator: Equipment
    {
        private readonly int shield;
        public ShieldGenerator() : base()
        {
            shield = 1;
        }
        public ShieldGenerator(int weigth, float health, float reliable, int cost, int _shield) : base(weigth, health, reliable, cost)
        {
            if (_shield < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _shield, this.ToString()), "Shield");
            }
            else
            {
                shield = _shield;
            }
        }
        public int Shield { get { return shield; } }
        public override string Print()
        {
            return "Shield: " + shield + "\n" + base.Print();
        }

    }
}
