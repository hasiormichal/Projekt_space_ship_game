using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal abstract class WeaponsDecorator : Weapon 
    {
        //TODO all decorator patern 
        protected Weapon MyWeapon;
        public WeaponsDecorator(Weapon _Ship , int _atack=10, int _weigth=20, float _health=100, float _reliable=(float)0.5, int _cost =  100) 
            : base(_atack,_weigth,_health,_reliable,_cost)
        {
            this.MyWeapon = _Ship;
        }
        public override int GetAtack(Ship targegShip)
        {
            return MyWeapon.GetAtack(targegShip);
        }
        public override int Repair()
        {
            return MyWeapon.Repair();
        }
        public override string Print()
        {
            return MyWeapon.Print();
        }
    }
}
