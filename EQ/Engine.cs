using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Engine : Equipment
    {
        private readonly int speed;
        private readonly int jumpRange;

        public Engine (int _weigth,float _health, float _reliable,int _cost, int _speed, int _jumprange): base(_weigth, _health, _reliable, _cost)
        {
            if (_speed < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _speed, this.ToString()), "Speed");
            }
            else
            {
                speed = _speed;
            }
            if (_jumprange < 0)
            {
                throw new ArgumentException(String.Format("{0} is < 0 in: {1}", _jumprange, this.ToString()), "JumpRange");
            }
            else
            {
                jumpRange = _jumprange;
            }
        }

        public int Speed { get { return speed; } }
        public int JumpRange { get { return jumpRange; } }

        public int Travel (Ship MyShip, int Distance)
        {
            //TODO
            return 1; 
        }
        public override string Print()
        {
            return "Speed: " + speed + "\n" + "Jump Range: " + jumpRange + "\n" + base.Print();
        }
    }
}
