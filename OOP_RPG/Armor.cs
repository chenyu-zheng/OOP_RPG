using System;
namespace OOP_RPG
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Armor(string name, int defense, int value) {
            Name = name;
            Defense = defense;
            OriginalValue = value;
            ResellValue = OriginalValue / 2;
        }
    }
}