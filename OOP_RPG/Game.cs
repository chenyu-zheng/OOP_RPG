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
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Shop");
            Console.WriteLine("4. Fight Monster");
            var input = Console.ReadLine();
            if (input == "1") {
                Stats();
            }
            else if (input == "2") {
                Inventory();
            }
            else if (input == "3")
            {
                Shop.Menu();
                Main();
            }
            else if (input == "4") {
                Fight();
            }
            else {
                return;
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