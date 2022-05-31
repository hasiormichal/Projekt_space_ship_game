// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Projekt
{
    class Program
    {
        private static Player Load()
        {
            string file = "F:/Git Programy/c#/Projekt/Projekt/XMLFile1.xml";
            Player listofa = new Player();
            XmlSerializer formatter = new XmlSerializer(listofa.GetType());
            FileStream aFile = new FileStream(file, FileMode.Open);
            byte[] buffer = new byte[aFile.Length];
            aFile.Read(buffer, 0, (int)aFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            return (Player)formatter.Deserialize(stream);
        }


        private static void Save(Player listofa)
        {
            string path = "F:/Git Programy/c#/Projekt/Projekt/XMLFile1.xml";
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(listofa.GetType());
            formatter.Serialize(outFile, listofa);
        }
        static void Main(string[] args)
        {
            try
            {
                MenuFunctions menuFunctions = new MenuFunctions();
                DictionaryMap WordMap = new DictionaryMap();
                Factory factory = new Factory();
                List<Planet> GlobalPlanetList = new List<Planet>();
                List<Dictionary<string, int>> WordMapNumber = new List<Dictionary<string, int>>() { WordMap.Earth, WordMap.Mars, WordMap.Jupiter,
                WordMap.Saturn, WordMap.Alfa3825,WordMap.Pandora,WordMap.Celestia,WordMap.Celestia, WordMap.Orion47,WordMap.Envito,WordMap.LastPlanet,};
                Planet Ziemia = new Planet("Ziemia", 20, 15, 0, 1);
                Planet Mars = new Planet("Mars", 25, 20, 1, 1);
                Planet Jupiter = new Planet("Jupiter", 20, 20, 2, 1);
                Planet Saturn = new Planet("Saturn", 30, 10, 3, 2);
                Planet Alfa3825 = new Planet("Alfa3825", 20, 20, 4, 2);
                Planet Pandora = new Planet("Pandora", 30, 15, 5, 2);
                Planet Celestia = new Planet("Celestia", 30, 25, 6, 2);
                Planet Orion47 = new Planet("Orion47", 20, 35, 7, 2);
                Planet Envito = new Planet("Envito", 30, 20, 8, 3);
                Planet LastPlanet = new Planet("LastPlanet", 45, 45, 9, 3);

                GlobalPlanetList.Add(Ziemia);
                GlobalPlanetList.Add(Mars);
                GlobalPlanetList.Add(Jupiter);
                GlobalPlanetList.Add(Saturn);
                GlobalPlanetList.Add(Alfa3825);
                GlobalPlanetList.Add(Pandora);
                GlobalPlanetList.Add(Celestia);
                GlobalPlanetList.Add(Orion47);
                GlobalPlanetList.Add(Envito);
                GlobalPlanetList.Add(LastPlanet);


                menuFunctions.PlanetList = GlobalPlanetList;
                RandomGenerator MyGenerator = new RandomGenerator();

                BlackList FinalBlackList = new BlackList(8, GlobalPlanetList);

                foreach (Planet planet in GlobalPlanetList)
                {
                    Player tempPlayer = MyGenerator.GeneratePlayer(planet);
                    planet.EnemyPlayer.Add(tempPlayer);
                }

                Player Me = MyGenerator.GeneratePlayer(Ziemia);
                Me.Name = "Dudus";
                Me.MyMoney += 10000;
                List <Player> ListToSave = new List<Player>();
                ListToSave.Add(Me);
                string[] MainMenu = { "exit", "Show my ship", "Repair", "Buy Fuel", "Buy Rockets","Buy Weapon", "Buy Eq","Travel", "figth","upgrade weapon","" +
                        "upgrade planet"};
                bool ExitFlag = true;
                string result;
                PrintMenu menu1 = new PrintMenu();
                menu1._menu = MainMenu;
                while (ExitFlag)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n               | Cost: " + (int)(1000 + Math.Pow(Me.Localization.PlanetLvl, 2) * 1500));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nMy money: " + Me.MyMoney + "$");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Planet: " + Me.Localization.Name + " | Plenet lvl: " + Me.Localization.PlanetLvl);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Fuel:" + Me.MyShip.FuelTank.Capacity + "/" + Me.MyShip.FuelTank.MaxCapacity +
                        " | Refile cost: " + Me.MyShip.FuelTank.FuelRefile(Me.Localization.FuelCost));
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
                            menuFunctions.MenuTravel(Me , WordMapNumber);

                            break;
                        case "figth":
                            menuFunctions.MenuFigth(Me);
                            break;
                        case "exit":
                            Console.Clear();
                            Console.WriteLine("Enter y/n to confirm.");
                            var exit = Console.ReadKey();
                            Save(Me);
                            if (exit.Key == ConsoleKey.Y)
                            {
                                ExitFlag = false;
                            }
                            break;
                        case "upgrade weapon":
                            menuFunctions.MenuUpgradeWeapon(Me);
                            break;
                        case "upgrade planet":
                            if (Me.MyMoney < (int)(1000 + Math.Pow(Me.Localization.PlanetLvl, 2) * 1500))
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
