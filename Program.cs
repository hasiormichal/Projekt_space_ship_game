// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace Projekt
{
    class Program
    {

        /*
        public static void MenuChoicePrintShip(Ship shipV1)
        {
            string[] MainMenu = { "engine", "fuel tank", "Shield generator", "droid", "hull", "weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5","exit" };
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            menu1._menu = MainMenu;
            while (ExitFlag)
            {
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "engine":
                        Console.WriteLine(shipV1.Engine.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "fuel tank":
                        Console.WriteLine(shipV1.FuelTank.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Shield generator":
                        Console.WriteLine(shipV1.ShieldGenerator.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "droid":
                        Console.WriteLine(shipV1.Droid.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "hull":
                        Console.WriteLine(shipV1.Hull.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "weapon 1":
                        if(shipV1.Weapons.Count >= 1)
                        {
                            Console.WriteLine(shipV1.Weapons[0].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 1 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "weapon 2":
                        if (shipV1.Weapons.Count >= 2)
                        {
                            Console.WriteLine(shipV1.Weapons[1].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 2 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 3":
                        if (shipV1.Weapons.Count >= 3)
                        {
                            Console.WriteLine(shipV1.Weapons[2].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 3 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 4":
                        if (shipV1.Weapons.Count >= 4)
                        {
                            Console.WriteLine(shipV1.Weapons[3].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 4 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 5":
                        if (shipV1.Weapons.Count >= 5)
                        {
                            Console.WriteLine(shipV1.Weapons[4].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 5 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "exit":
                        ExitFlag = false;
                        break;
                }
            }
        }
        */
        static void Main(string[] args)
        {
            try
            {
                MenuFunctions menuFunctions = new MenuFunctions();
                DictionaryMap WordMap = new DictionaryMap();
                Factory factory = new Factory();
                List<Planet> GlobalPlanetList = new List<Planet>();
                Planet Ziemia = new Planet("Ziemia",20,15,WordMap.Earth,1);
                Planet Mars = new Planet("Mars",25,20,WordMap.Mars,1);
                Planet Jupiter = new Planet("Jupiter", 20, 20, WordMap.Jupiter, 1);
                Planet Saturn = new Planet("Saturn", 30, 10, WordMap.Saturn, 2);

                GlobalPlanetList.Add(Ziemia);
                GlobalPlanetList.Add(Mars);
                GlobalPlanetList.Add(Jupiter);
                GlobalPlanetList.Add(Saturn);

                menuFunctions.PlanetList = GlobalPlanetList;
                RandomGenerator MyGenerator = new RandomGenerator();


                Player Me = MyGenerator.GeneratePlayer(Ziemia);
                Me.Name = "Dudus";
                Me.MyMoney += 50000;

                string[] MainMenu = { "exit", "Show my ship", "Repair", "Buy Fuel", "Buy Rockets","Buy Weapon", "Buy Eq","Travel", "figth","upgrade weapon","" +
                        "upgrade planet"};
                bool ExitFlag = true;
                string result;
                PrintMenu menu1 = new PrintMenu();
                menu1._menu = MainMenu;
                while (ExitFlag)
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\nMy money: " + Me.MyMoney + "$");
                    Console.WriteLine("Fuel:" + Me.MyShip.FuelTank.Capacity + "/" + Me.MyShip.FuelTank.MaxCapacity +
                        "| Refile cost: " + Me.MyShip.FuelTank.FuelRefile(Me.Localization.FuelCost));
                    int TotalRocketCost = 0;
                    RocketLauncher tempRocket = new RocketLauncher(10, 30, 100, (float)0.9, 100, 30);
                    foreach (Weapon weapons in Me.MyShip.Weapons)
                    {
                        if (weapons.GetType() == tempRocket.GetType())
                        {
                            tempRocket = (RocketLauncher)weapons;
                            Console.WriteLine("Rockets: " + tempRocket.MagazinSize + "/" + tempRocket.MaxMagazinSize);
                            TotalRocketCost += tempRocket.BuyRocket(Me.Localization.RocketCost);
                        }

                    }
                    Console.WriteLine("Total rockets cost: " + TotalRocketCost + "$");
                    result = menu1.MenuToPrint();
                    switch (result)
                    {
                        case "Buy Fuel":
                            if (Me.MyMoney - Me.MyShip.FuelTank.FuelRefile(Me.Localization.FuelCost) < 0)
                            {
                                Console.WriteLine("Not enougth money");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Me.MyMoney -= Me.MyShip.FuelTank.FuelRefile(Me.Localization.FuelCost);
                                Me.MyShip.FuelTank.Capacity = Me.MyShip.FuelTank.MaxCapacity;
                                break;
                            }
                        case "Buy Rockets":
                            if (Me.MyMoney < TotalRocketCost)
                            {
                                Console.WriteLine("Not enougth money");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                for (int i = 0; i < Me.MyShip.Weapons.Count; i++)
                                {
                                    if (Me.MyShip.Weapons[i].GetType() == tempRocket.GetType())
                                    {
                                        tempRocket = (RocketLauncher)Me.MyShip.Weapons[i];
                                        tempRocket.MagazinSize = tempRocket.MaxMagazinSize;
                                        Me.MyShip.Weapons[i] = tempRocket;
                                    }
                                }
                                Me.MyMoney -= TotalRocketCost;
                                break;
                            }
                        case "Show my ship":
                            menuFunctions.MenuChoicePrintShip(Me);
                            break;
                        case "Repair":
                            menuFunctions.MenuChoicePrintRepair(Me);
                            break;
                        case "Buy Weapon":
                            menuFunctions.MenuBuyWeapon(Me);
                            break;
                        case "Buy Eq":
                            menuFunctions.MenuBuyEQ(Me.Localization, Me);
                            break;
                        case "Travel":
                            menuFunctions.MenuTravel(Me);
                            
                            break;
                        case "figth":
                            List<Player> PlayerList = new List<Player>();
                            PlayerList.Add(MyGenerator.GeneratePlayer(Me.Localization));
                            PlayerList.Add(MyGenerator.GeneratePlayer(Me.Localization));
                            menuFunctions.MenuFigth(Me, PlayerList);
                            break;
                        case "exit":
                            ExitFlag = false;
                            break;
                        case "upgrade weapon":
                            menuFunctions.MenuUpgradeWeapon(Me);
                            break;
                        case "upgrade planet":
                            Console.Clear();
                            string[] ChoiceMenu = { "Exit","upgrage" };
                            string ChoiceResult;
                            bool ChoiceExitFlag = true;
                            PrintMenu menu2 = new PrintMenu();
                            menu2._menu = ChoiceMenu;
                            
                            while (ChoiceExitFlag)
                            {
                                Console.Clear();
                                Console.WriteLine("\n\n\nUpgrade Cost: " + (int)(1000+ Math.Pow(Me.Localization.PlanetLvl, 2) * 1500));
                                Console.WriteLine("My money: " + Me.MyMoney);
                                ChoiceResult = menu2.MenuToPrint();
                                switch (ChoiceResult)
                                {
                                    case "Exit":
                                        ChoiceExitFlag = false;
                                        break;
                                    case "upgrage":
                                        if(Me.MyMoney < (int)(1000 + Math.Pow(Me.Localization.PlanetLvl, 2) * 1500))
                                        {
                                            Console.WriteLine("Not enougth money");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            Me.MyMoney -= (int)(1000 + Math.Pow(Me.Localization.PlanetLvl, 2) * 1500);
                                            Me.Localization.PlanetLvl++;
                                            Console.WriteLine("Succesfull upgrade");
                                            Console.ReadKey();
                                            Console.Clear();
                                            ChoiceExitFlag = false;
                                        }
                                        break;
                                }
                            }
                            break;

                    }
                }


            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }
    }
}
