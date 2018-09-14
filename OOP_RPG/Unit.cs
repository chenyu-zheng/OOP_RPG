using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public abstract class Unit
    {
        public string Name { get; set; }
        public int OriginalStrength { get; set; }
        public int OriginalDefense { get; set; }
        public int OriginalHP { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        public int Gold { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Strength
        {
            get { return OriginalStrength + (EquippedWeapon?.Strength ?? 0); }
        }
        public int Defense
        {
            get { return OriginalDefense + (EquippedArmor?.Defense ?? 0); }
        }
    }
}
