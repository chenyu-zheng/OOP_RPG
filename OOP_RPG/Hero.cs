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
            Console.WriteLine("======== " + this.Name + " ========");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }
        
        public void ShowInventory() {
            Console.WriteLine("========  INVENTORY ========");
            Console.WriteLine("----- Weapons -----");
            Items.Where(p => p is Weapon).ToList()
                .ForEach(w => Console.WriteLine(w.Name + " of " + ((Weapon)w).Strength + " Strength"));
            Console.WriteLine("----- Armors -----");
            Items.Where(p => p is Armor).ToList()
                .ForEach(w => Console.WriteLine(w.Name + " of " + ((Armor)w).Defense + " Defense"));
            Console.WriteLine("----- Potions -----");
            Items.Where(p => p is Potion).ToList()
                .ForEach(w => Console.WriteLine(w.Name + " of " + ((Potion)w).HP + " HP"));
            Console.WriteLine($"Gold: {Gold}");

        }

        public void Equip(int itemIndex)
        {
            IItem item = Items[itemIndex];
            if (item is Weapon)
            {
                EquippedWeapon = (Weapon)Items[itemIndex];
            }
            else if (item is Armor)
            {
                EquippedArmor = (Armor)Items[itemIndex];
            }
            else
            {
                Console.WriteLine($"{item} is not equippable!");
            }
        }

        public void AddItem(IItem item)
        {
            if (item is Weapon)
            {
                Items.Add((Weapon)item);
            } 
            else if (item is Armor)
            {
                Items.Add((Armor)item);
            }
            else if (item is Potion)
            {
                Items.Add((Potion)item);
            }
        }
        
        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
        }
    }
}