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
                Planet Ziemia = new Planet("Ziemia",10,10,WordMap.Ziemia,1);
                Planet Mars = new Planet("Mars",50,50,WordMap.Mars,1);
                RandomGenerator MyGenerator = new RandomGenerator();



                List <Weapon> listV2 = new List<Weapon>();
                Tetronik TetronikGenV1 = factory.GenerateTetronik(1);
                HeavyCannon heavyCannonGenV2 = factory.GenerateHeavyCannon(2);
                listV2.Add(TetronikGenV1);
                listV2.Add(heavyCannonGenV2);

                Engine EngineGenV2 = factory.GenerateEngine(2);
                FuelTank FuelGenV2 = factory.GeneratorFuelTank(2);
                Droid DroidGenV2 = factory.GenerateDroid(2);
                ShieldGenerator ShieldGenV2 = factory.GeneratorShieldGenerator(2);
                Hull HullGenV2 = factory.GenerateHull(3);

                Ship ShipV2 = new Ship(HullGenV2,listV2,EngineGenV2,FuelGenV2,ShieldGenV2,DroidGenV2);
                //Console.WriteLine(ShipV1.ShowShipStatus());


                Player Me = MyGenerator.GeneratePlayer(1, Ziemia);
                Me.Name = "Dudus";
                Me.MyMoney += 5000;

                //Figth(Me, Enemy);
                //Console.ReadKey();

                string[] MainMenu = { "Show my ship", "Repair", "Buy Weapon", "Buy Eq", "figth","upgrade" , "exit" };
                bool ExitFlag = true;
                string result;
                PrintMenu menu1 = new PrintMenu();
                menu1._menu = MainMenu;
                while (ExitFlag)
                {
                    Console.Clear();
                    result = menu1.MenuToPrint();
                    switch (result)
                    {
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
                        case "figth":
                            Player TempPlayer = MyGenerator.GeneratePlayer(1, Me.Localization);Console.Clear();
                            menuFunctions.MenuFigth(Me, TempPlayer);
                            Console.ReadKey();
                            break;
                        case "exit":
                            ExitFlag = false;
                            break;
                        case "upgrade":
                            Console.Clear();
                            string[] ChoiceMenu = { "upgrage", "Exit" };
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
