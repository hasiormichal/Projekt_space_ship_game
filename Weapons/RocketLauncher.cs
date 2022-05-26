using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class RocketLauncher : Weapon
    {
        private readonly int maxMagazinSize;
        private int magazinSize;
        public RocketLauncher(int atack, int weigth, float healt, float reliable, int cost, int _maxMagazinSize) : base(atack, weigth, healt, reliable, cost)
        {
            if (_maxMagazinSize < 0 || _maxMagazinSize > 50)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 10 in: {1}", _maxMagazinSize, this.ToString()), "MaxMagazinSize");
            }
            else
            {
                maxMagazinSize = _maxMagazinSize;
                MagazinSize = _maxMagazinSize;
            }
        }

        public int MaxMagazinSize { get { return maxMagazinSize; } }
        public int MagazinSize
        {
            get { return magazinSize; }
            set
            {
                if (value < 0 || value > maxMagazinSize)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 or > {1} in: {2}", value, maxMagazinSize, this.ToString()), "MagazinSize");
                }
                else
                {
                    magazinSize = value;
                }
            }
        }
        public override int GetAtack(Ship TargetShip)
        {
            //in fuction Ship.UseWeapon we call GetAtack 3 time, so we use 3 rocket !!!!!
            int atack;
            if(magazinSize > 0)
            {
                if (TargetShip.ShieldGenerator.BaseHealth > 0)
                {
                    atack = (this.BaseAtack) - (this.BaseAtack*TargetShip.ShieldGenerator.Shield/100) - TargetShip.Hull.Armor;
                    magazinSize--;
                }
                else
                {
                    atack = this.BaseAtack - TargetShip.Hull.Armor;
                    magazinSize--;
                }
            }
            else
            {
                atack = 0;
            }
            return atack;
        }

        public int BuyRocket(int Price)
        {
            return (maxMagazinSize - magazinSize) * Price;
        }
        public override string Print()
        {
            return this.PrintName() + "\nMagazin Size: " + maxMagazinSize + " ==> " + "Rockets: " + magazinSize +"\n"+  base.Print();
        }
        public override string PrintName()
        {
            return "Rocket Launcher";
        }
    }
}
