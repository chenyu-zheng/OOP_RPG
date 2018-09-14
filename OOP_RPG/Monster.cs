using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster : Unit
    {
        

        public Monster(string name, int strength, int defense, int hp, int speed, int gold = 0)
        {
            Name = name;
            OriginalStrength = strength;
            OriginalDefense = defense;
            OriginalHP = hp;
            HP = hp;
            Speed = speed;
            Gold = gold;
        }
    }
}