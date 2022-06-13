// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace Projekt
{
    class Program
    {
        async static void SaveScore(List <string> list, string path)
        {
            string StringToSave = "---\n";
            foreach (var item in list)
            {
                StringToSave += item.ToString() +"\n";
            }
            await File.WriteAllTextAsync(path, StringToSave);
        }
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
                Planet Alfa3825 = new Planet("Alfa3825", 20, 20, WordMap.Alfa3825, 2);
                Planet Pandora = new Planet("Pandora", 30, 15, WordMap.Pandora, 2);
                Planet Celestia = new Planet("Celestia", 30, 25, WordMap.Celestia, 2);
                Planet Orion47 = new Planet("Orion47", 20, 35, WordMap.Orion47, 2);
                Planet Envito = new Planet("Envito", 30, 20, WordMap.Envito, 3);
                Planet LastPlanet = new Planet("LastPlanet",45,45,WordMap.LastPlanet, 3);

                List<String> Score = new List<string>();

                //SaveScore(Score, "F:/Git Programy/c#/Projekt/Projekt/score.txt");
                string[] lines = System.IO.File.ReadAllLines("F:/Git Programy/c#/Projekt/Projekt/score.txt");
               for(int i = 1; i < lines.Length; i++)
                {
                    Score.Add(lines[i]);
                }
                /*
                for (int i=1; i<lines.Count(); i++)
                {
                    int position = lines[i].IndexOf(",", 2);
                    string temp = lines[i].Substring(1, position-1);
                   // temp = lines[i].Substring(position + 1, lines[i].IndexOf("]", position));
                    int number = Int32.Parse(lines[i].Substring(position + 1, lines[i].IndexOf("]", position)-1- position));
                    Score[temp] = number;
                }
               */
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

                Console.WriteLine("----- Welcome in Galaxy Ship Game -----\n Enter your Name:\n ");
                string ? name = Console.ReadLine();
                if(name == null)
                {
                    Console.WriteLine("error\n");
                }
                Console.Clear();

                Player Me = MyGenerator.GeneratePlayer(Ziemia);
                Me.Name = name;
                Me.MyMoney += 10000;
                Me.Score = 0;

                string[] MainMenu = { "exit", "Show my ship", "Repair", "Buy Fuel", "Buy Rockets","Buy Weapon", "Buy Eq","Travel", "figth","upgrade weapon","" +
                        "upgrade planet"};
                bool ExitFlag = true;
                string result;
                PrintMenu menu1 = new PrintMenu();
                menu1._menu = MainMenu;
                while (ExitFlag)
                {
                    Console.Clear();
                    if(Me.Localization.PlanetLvl >=5)
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n               | Max lvl");
                    }
                    else
                    {
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n               | Cost: " + (int)(1000 + Math.Pow(Me.Localization.PlanetLvl, 2) * 1500));

                    }
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
                            menuFunctions.MenuTravel(Me);
                            
                            break;
                        case "figth":
                            menuFunctions.MenuFigth(Me);
                            if(Me.MyShip.Hull.Health <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You lose!!! \n Score: {0}", Me.Score);
                                //Score.Add(Me.Name, Me.Score);
                                Score.Add(Me.Name + " " + Me.Score);
                                SaveScore(Score, "F:/Git Programy/c#/Projekt/Projekt/score.txt");
                                ExitFlag = false;
                            }
                            if(FinalBlackList.blackPlayerList[0].MyShip.Hull.Health == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("You Win!!! \n Score: {0}", Me.Score);
                                //Score.Add(Me.Name, Me.Score);
                                Score.Add(Me.Name + " " + Me.Score);
                                SaveScore(Score, "F:/Git Programy/c#/Projekt/Projekt/score.txt");
                                ExitFlag = false;
                            }
                            break;
                        case "exit":
                            Console.Clear();
                            Console.WriteLine("Enter y/n to confirm.");
                            var exit = Console.ReadKey();
                            if (exit.Key == ConsoleKey.Y)
                            {
                                Score.Add(Me.Name + " " + Me.Score);
                                SaveScore(Score, "F:/Git Programy/c#/Projekt/Projekt/score.txt");
                                ExitFlag = false;
                            }
                            break;
                        case "upgrade weapon":
                            menuFunctions.MenuUpgradeWeapon(Me);
                            break;
                        case "upgrade planet":
                            if(Me.Localization.PlanetLvl >= 5)
                            {
                                break;
                            }
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
