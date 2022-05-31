using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Equipment : IFEquipment
    {
        protected readonly int baseWeigth;
        protected float baseHealth; //Max 100
        protected readonly float baseReliable;
        protected readonly int cost;

        public Equipment()
        {
            baseWeigth = 1;
            baseHealth = 100;
            baseReliable = (float)0.99;
            cost = 1;
        }
        public Equipment(int _weigth, float _haelth, float _reliable, int _cost)
        {
            if (_weigth < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _weigth, this.ToString()), "Weigth");
            }
            else
            {
                baseWeigth = _weigth;
            }
            if (_haelth < 0 || _haelth > 100)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 100 in {1}" , _haelth, this.ToString()), "Health");
            }
            else
            {
                baseHealth = _haelth;
            }
            if (_reliable < 0 || _reliable > 100)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or >100 in: {1}", _reliable, this.ToString()), "Reliable");
            }
            else
            {
                baseReliable = _reliable;
            }
            if (_cost < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _cost, this.ToString()), "Cost");
            }
            else
            {
                cost = _cost;
            }
        }

        public int BaseWeigth { get { return baseWeigth; } }
        public float BaseHealth { get { return baseHealth; } set { this.baseHealth = value; } }
        public float BaseReliable { get { return baseReliable; } }
        public int Cost { get { return cost; } }
        public int Repair()
        {
            return (int)((100.0 - baseHealth) * cost / 1000);
        }
        public virtual string Print()
        {
            string temp = "Weigth: " + baseWeigth +"\n";
            temp += "Health: " + baseHealth + "\n";
            temp += "Reliable: " + baseReliable + "\n";
            temp += "Cost: " + cost + "\n";
            return temp;
        }
    }
}
