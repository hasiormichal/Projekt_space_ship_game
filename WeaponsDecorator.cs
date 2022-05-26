using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal abstract class WeaponsDecorator : IFWeapon
    {
        //TODO all decorator patern 
        protected Weapon weapon { get; set; }
        public WeaponsDecorator(Weapon _Ship)
        {
            weapon = _Ship;
        }
        public int GetAtack(Ship targegShip)
        {
            return weapon.GetAtack(targegShip);
        }
        public int Repair()
        {
            return weapon.Repair();
        }
    }
}
