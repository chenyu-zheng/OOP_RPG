using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        public List<IItem> Items { get; set; }
        public Hero Hero;

        public Shop(Hero hero)
        {
            Hero = hero;
            Items = new List<IItem>
            {
                new Weapon("Dagger", 3, 20),
                new Weapon("Short Sword", 7, 100),
                new Weapon("Sabre", 11, 250),
                new Weapon("Zweihander", 19, 800),

                new Armor("Leather Armor", 2, 30),
                new Armor("Ring Mail", 4, 120),
                new Armor("Scale Mail", 6, 300),
                new Armor("Light Plate", 8, 1100),

                new Potion("Minor Potion", 5, 5),
                new Potion("Light Potion", 10, 12),
                new Potion("Normal Potion", 20, 30),
                new Potion("Greater Potion", 50, 80)
            };
        }

        public Shop(Hero hero, List<Weapon> weapons, List<Armor> armors, List<Potion> potions)
        {
            Hero = hero;
            Items = weapons.ToList<IItem>().Concat(armors).Concat(potions).ToList();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("**************** SHOP ****************");
                Console.WriteLine("Welcome! What would you like to do?");
                Console.WriteLine("1. Buy");
                Console.WriteLine("2. Sell");
                Console.WriteLine("3. Return to Game Menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "":
                        continue;
                    case "1":
                        ListShopItems();
                        break;
                    case "2":
                        ListHeroItems();
                        break;
                    default:
                        return;
                }
            }
        }

        public void ListShopItems()
        {
            int num = 1;
            Console.WriteLine("======== Shop Item List ========");
            Console.WriteLine("No. | Name | Price ");
            Console.WriteLine("----- Weapons -----");
            Items.Where(p => p is Weapon).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.OriginalValue}"));
            Console.WriteLine("----- Armors -----");
            Items.Where(p => p is Armor).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.OriginalValue}"));
            Console.WriteLine("----- Potions -----");
            Items.Where(p => p is Potion).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.OriginalValue}"));
            Console.WriteLine($"[Your Gold: {Hero.Gold}] Enter an item number to buy:");

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int itemNumber))
            {
                Buy(itemNumber - 1);
            }
        }

        public void Buy(int itemNumber)
        {
            if (itemNumber >= Items.Count || itemNumber < 0)
            {
                Console.WriteLine($"Item number does not exist!");
                return;
            }
            IItem item = Items[itemNumber];
           if (Hero.Gold >= item.OriginalValue)
            {
                Hero.Gold -= item.OriginalValue;
                Hero.AddItem(item);
                Console.WriteLine($"You bought {item.Name} for {item.OriginalValue} gold.");
            } else
            {
                Console.WriteLine($"Insufficient gold!");
            }
        }

        public void ListHeroItems()
        {
            int num = 1;
            Console.WriteLine("======== Hero Item List ========");
            Console.WriteLine("No. | Name | Resell Price ");
            Console.WriteLine("----- Weapons -----");
            Hero.Items.Where(p => p is Weapon).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.ResellValue}"));
            Console.WriteLine("----- Armors -----");
            Hero.Items.Where(p => p is Armor).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.ResellValue}"));
            Console.WriteLine("----- Potions -----");
            Hero.Items.Where(p => p is Potion).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  ${p.ResellValue}"));
            Console.WriteLine($"Enter an item number to sell:");

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int itemNumber))
            {
                Sell(itemNumber - 1);
            }
        }

        public void Sell(int itemNumber)
        {
            if (itemNumber >= Hero.Items.Count || itemNumber < 0)
            {
                Console.WriteLine($"Item number does not exist!");
                return;
            }
            IItem item = Hero.Items[itemNumber];
            Hero.Gold += item.ResellValue;
            Hero.RemoveItem(item);
            Console.WriteLine($"You sold {item.Name} for {item.ResellValue} gold.");
        }
    }
}
