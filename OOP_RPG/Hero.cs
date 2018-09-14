using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Gold { get; set; }
        public List<IItem> Items { get; set; }

        public int CurrentStrength
        {
            get { return Strength + EquippedWeapon?.Strength ?? 0; }
        }
        public int CurrentDefense
        {
            get { return Defense + EquippedArmor?.Defense ?? 0; }
        }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero() {
            Items = new List<IItem>();
            Strength = 10;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            Gold = 50;
        }

        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("======== " + Name + " ========");
            Console.WriteLine($"Strength: {CurrentStrength} (+{EquippedWeapon?.Strength ?? 0})");
            Console.WriteLine($"Deffense: {CurrentDefense} (+{EquippedArmor?.Defense ?? 0})");
            Console.WriteLine("Hitpoints: " + CurrentHP + "/" + OriginalHP);
            Console.WriteLine($"Gold: { Gold }");
        }
        
        public void ShowInventory() {
            int num = 1;
            Console.WriteLine("========  INVENTORY ========");
            Console.WriteLine("No. | Name | Property ");
            Console.WriteLine("----- Weapons -----");
            Items.Where(p => p is Weapon).Select(p => (Weapon)p).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  STR+{p.Strength}  {(p == EquippedWeapon ? "E" : "")}"));
            Console.WriteLine("----- Armors -----");
            Items.Where(p => p is Armor).Select(p => (Armor)p).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  DEF+{p.Defense}  {(p == EquippedArmor ? "E" : "")}"));
            Console.WriteLine("----- Potions -----");
            Items.Where(p => p is Potion).Select(p => (Potion)p).ToList()
                .ForEach(p => Console.WriteLine($"{num++})  {p.Name}  HP:{p.HP}"));
            Console.WriteLine($"Enter an item number to use:");

            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int itemNumber))
            {
                UseInventoryItem(itemNumber - 1);
            }
        }

        public void UseInventoryItem(int itemIndex)
        {
            if (Items[itemIndex] is Potion p)
            {
                UsePotion(p);
            }
            else
            {
                Equip(Items[itemIndex]);
            }
        }

        public void UsePotion(Potion potion)
        {
            if (CurrentHP == OriginalHP)
            {
                Console.WriteLine($"Your HP is full.");
            }
            int r = potion.HP < OriginalHP - CurrentHP ? potion.HP : OriginalHP - CurrentHP;
            RemoveItem(potion);
            CurrentHP += r;
            Console.WriteLine($"{potion.Name} restored you {r} HP.");
        }

        public void Equip(IItem item)
        {
            if (item is Weapon w)
            {
                EquippedWeapon = w;
                Console.WriteLine($"{item.Name} is equiped");
            }
            else if (item is Armor a)
            {
                EquippedArmor = a;
                Console.WriteLine($"{item.Name} is equiped");
            }
            else
            {
                Console.WriteLine($"{item.Name} is not equippable!");
            }
        }

        public void AddItem(IItem item)
        {
            if (item is Weapon w)
            {
                Items.Add(new Weapon(w.Name, w.Strength, w.OriginalValue));
            }
            else if (item is Armor a)
            {
                Items.Add(new Armor(a.Name, a.Defense, a.OriginalValue));
            }
            else if (item is Potion p)
            {
                Items.Add(new Potion(p.Name, p.HP, p.OriginalValue));
            }
        }
        
        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
            if (item == EquippedWeapon)
            {
                EquippedWeapon = null;
            }
            if (item == EquippedArmor)
            {
                EquippedArmor = null;
            }
        }
    }
}