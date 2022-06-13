using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class BlackList
    {
        private int listNumber;
        public List<Player> blackPlayerList;


        public BlackList (int _listNumber, List<Planet> GlobalPlanetList)
        {
            this.listNumber = _listNumber;
            blackPlayerList = new List<Player>();
            RandomGenerator TempFactory = new RandomGenerator();
            if (_listNumber >= 1)
            {
                
                Player temp = new Player("Black List nr. 1", new Ship(new Hull(15, 1300, 1000, 5, 500000), new List<Weapon>()
                    {
                    new AtomicVision(100,100,100,(float)0.99,50000,(float)2),
                    new AtomicVision(100,100,100,(float)0.99,50000,(float)2),
                    new AtomicVision(100,100,100,(float)0.99,50000,(float)2),
                    new AtomicVision(100,100,100,(float)0.99,50000,(float)2),
                    new AtomicVision(100,100,100,(float)0.99,50000,(float)2),
                    }
                    , new Engine(50, 100, (float)0.99, 20000, 350, 50), new FuelTank(50, 100, (float)0.99, 10000, 50), new ShieldGenerator(50, 100, (float)0.99, 20000, 50),
                    new Droid(50, 100, (float)0, 99, 50)), //end ship EQ
                    200000, GlobalPlanetList[8]
                    ); 
                GlobalPlanetList[8].EnemyPlayer.Add(temp); // planet have his own playr list, so we should add there blackList players
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 2)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[7]);
                temp.Name = "Black List nr. 2";
                temp.MyMoney += 75000;
                GlobalPlanetList[7].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 3)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[7]);
                temp.Name = "Black List nr. 3";
                temp.MyMoney += 50000;
                GlobalPlanetList[7].EnemyPlayer.Add(temp); 
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 4)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[6]);
                temp.Name = "Black List nr. 4";
                temp.MyMoney += 40000;
                GlobalPlanetList[6].EnemyPlayer.Add(temp); 
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 5)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[5]);
                temp.Name = "Black List nr. 5";
                temp.MyMoney += 30000;
                GlobalPlanetList[5].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 6)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[4]);
                temp.Name = "Black List nr. 6";
                temp.MyMoney += 20000;
                GlobalPlanetList[4].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 7)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[4]);
                temp.Name = "Black List nr. 7";
                temp.MyMoney += 12500;
                GlobalPlanetList[4].EnemyPlayer.Add(temp); 
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 8)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[3]);
                temp.Name = "Black List nr. 8";
                temp.MyMoney += 7500;
                GlobalPlanetList[3].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 8)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[3]);
                temp.Name = "Black List nr. 8";
                temp.MyMoney += 7500;
                GlobalPlanetList[3].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
            if (_listNumber >= 8)
            {
                Player temp = TempFactory.GeneratePlayer(GlobalPlanetList[1]);
                temp.Name = "Black List nr. 8";
                temp.MyMoney += 7500;
                GlobalPlanetList[1].EnemyPlayer.Add(temp);
                blackPlayerList.Add(temp);

            }
        }
    }
}
