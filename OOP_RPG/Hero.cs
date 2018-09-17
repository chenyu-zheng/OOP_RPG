using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero : Unit
    {
        public List<IItem> Items { get; set; }

        public Hero() {
            Items = new List<IItem>();
            OriginalStrength = 10;
            OriginalDefense = 10;
            OriginalHP = 30;
            HP = 30;
            Speed = 10;
            Gold = 50;
        }

        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("======== " + Name + " ========");
            Console.WriteLine($"Strength: {Strength} (+{EquippedWeapon?.Strength ?? 0})");
            Console.WriteLine($"Deffense: {Defense} (+{EquippedArmor?.Defense ?? 0})");
            Console.WriteLine("Hitpoints: " + HP + "/" + OriginalHP);
            Console.WriteLine($"Speed: { Speed }");
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
            if (itemIndex >= Items.Count || itemIndex < 0)
            {
                Console.WriteLine($"Item number does not exist!");
                return;
            }
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
            if (HP == OriginalHP)
            {
                Console.WriteLine($"Your HP is full.");
            }
            int r = potion.HP < OriginalHP - HP ? potion.HP : OriginalHP - HP;
            RemoveItem(potion);
            HP += r;
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