using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Droid : Equipment
    {
        private readonly int repairPower;
        public Droid(int _weigth, float _health, float _reliable, int _cost, int _repairpower) : base(_weigth, _health, _reliable, _cost)
        {
            if (_repairpower < 0)
            { 
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _repairpower, this.ToString()), "RepairPower");
            }
            else
            {
                repairPower = _repairpower;
            }
        }

        public int RepairPower { get { return repairPower; } }
        public override string Print()
        {
            return "Repair Power: " + repairPower + "\n" + base.Print();
        }
    }
}
