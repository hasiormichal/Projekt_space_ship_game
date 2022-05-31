using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class FuelTank : Equipment
    {
        private readonly int maxCapacity;
        private int capacity;

        public FuelTank() : base()
        {
            maxCapacity = 1;
            capacity = 1;
        }
        public FuelTank(int _weigth, float _health, float _reliable, int _cost, int _maxcapacity) : base(_weigth, _health, _reliable, _cost)
        {
            if (_maxcapacity < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _maxcapacity, this.ToString()), "MaxCapacity");
            }
            else
            {
                maxCapacity = _maxcapacity;
            }
        }
        public int MaxCapacity { get { return maxCapacity; } }

        public int Capacity { 
            get { return capacity; } 
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 in: {1}", value , this.ToString()), "Capacity");
                }
                if(value > maxCapacity)
                {
                    throw new ArgumentException(String.Format("{0} is > {1} in: {2}", value, this.maxCapacity, this.ToString()) , "Capacity");
                }
                else
                {
                    capacity = value;
                }
            } 
        }

        public int FuelRefile (int cost)
        {
            int temp = MaxCapacity - Capacity;
            return temp * cost;
        }
        public override string Print()
        {
            return "MaxCapacity: " + maxCapacity + "\n" + "Capacity: " + Capacity + "\n" + base.Print();
        }
    }
}
