using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; set; }
        public Shop Shop { get; set; }
        
        public Game() {
            Hero = new Hero();
            Shop = new Shop(Hero);
        }
            
        public void Start() {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            Hero.Name = Console.ReadLine();
            Console.WriteLine("Hello " + Hero.Name);
            Main();
        }
        
        public void Main() {
            Console.WriteLine("**************** MAIN MENU ****************");
            while (true)
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Shop");
                Console.WriteLine("4. Fight Monster");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "":
                        continue;
                    case "1":
                        Stats();
                        break;
                    case "2":
                        Inventory();
                        break;
                    case "3":
                        Shop.Menu();
                        Main();
                        break;
                    case "4":
                        Fight();
                        break;
                    default:
                        return;
                }
            }
        }
        
        public void Stats() {
            Hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Main();
        }
        
        public void Inventory(){
            Hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Main();
        }
        
        public void Fight(){
            var fight = new Fight(Hero, this);
            fight.Start();
        }
    }
}