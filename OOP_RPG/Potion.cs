using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Potion : IItem
    {
        public string Name;
        public int HP;
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Potion(string name, int hp, int value)
        {
            Name = name;
            HP = hp;
            OriginalValue = value;
            ResellValue = OriginalValue / 2;
        }
    }
}
