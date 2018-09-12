using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Potion> Potions { get; set; }

        public Shop()
        {
            Weapons.Add(new Weapon("Dagger", 3, 20));
            Weapons.Add(new Weapon("Short Sword", 7, 100));
            Weapons.Add(new Weapon("Sabre", 11, 250));
            Weapons.Add(new Weapon("Zweihander", 19, 800));

            Armors.Add(new Armor("Leather Armor", 2, 30));
            Armors.Add(new Armor("Ring Mail", 4, 120));
            Armors.Add(new Armor("Scale Mail", 6, 300));
            Armors.Add(new Armor("Light Plate", 8, 1100));

            Potions.Add(new Potion("Minor Potion", 5, 5));
            Potions.Add(new Potion("Light Potion", 10, 12));
            Potions.Add(new Potion("Normal Potion", 20, 30));
            Potions.Add(new Potion("Greater Potion", 50, 80));
        }
    }
}
