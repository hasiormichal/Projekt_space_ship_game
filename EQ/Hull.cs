using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Hull: IFEquipment
    {
        private readonly int armor;
        private readonly int maxHealth;
        private int health;
        private readonly int maxWeigth;
        private readonly int maxNumberOfWeapons;
        private readonly int cost;

        public Hull(int _armor, int _maxhealth, int _maxweigth, int _maxweanpons, int _cost)
        {
            if (_armor < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _armor, this.ToString()), "Armor");
            }
            else
            {
                armor = _armor;
            }
            if (_maxhealth < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _maxhealth, this.ToString()), "MaxHealth");
            }
            else
            {
                maxHealth = _maxhealth;
                Health = _maxhealth;
            }
            if (_maxweigth < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _maxweigth, this.ToString()), "Weigth");
            }
            else
            {
                maxWeigth = _maxweigth;
            }
            if (_maxweanpons < 0 || _maxweanpons>5)
            {
                throw new ArgumentException(String.Format("{0} is < 0  or > 5 in: {1}", _maxweanpons, this.ToString()), "MaxNumberOfWeapons");
            }
            else
            {
                maxNumberOfWeapons = _maxweanpons;
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

        public int Armor { get { return armor; } }
        public int MaxHealth { get { return maxHealth; } }
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 in: {1}", value, this.ToString()), "GetHealth");
                }
                if (value > maxHealth)
                {
                    throw new ArgumentException(String.Format("{0} is > {1} in: {2}", value, this.maxHealth, this.ToString()), "GetHealth");
                }
                else
                {
                    health = value;
                }
            }
        }
        public int MaxWeigth { get { return maxWeigth; } }
        public int MaximumNumberOfWeapons { get { return maxNumberOfWeapons; } }
        public int Cost { get { return cost; } }

        public int Repair()
        {
            return (maxHealth - health) * 2;
        }
        public virtual string Print()
        {
        string temp = "Armor: " + armor + "\n";
            temp += "Max Health: " + maxHealth + "\n";
            temp += "Health: " + health + "\n";
            temp += "Weigth: " + maxWeigth + "\n";
            temp += "Max Number Of Weapons: " + maxNumberOfWeapons + "\n";
            temp += "Cost: " + cost + "\n";
            return temp;
        }
    }
}
