using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        Monster Monster { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        
        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.Monster = null;
            this.hero = hero;
            this.game = game;
            this.AddMonster("Slime", 2, 4, 12);
            this.AddMonster("Rat", 11, 8, 18);
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Bat", 10, 6, 17);
            this.AddMonster("Lizard", 10, 14, 25);
            this.AddMonster("Bear", 17, 17, 80);
            this.AddMonster("Troll", 23, 12, 65);
            this.AddMonster("Wyvern", 180, 190, 450);
        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster(name, strength, defense, hp);
            this.Monsters.Add(monster);
        }
        
        public void Start() {
            var lastMonster = Monsters.Last();
            var secondMonster = Monsters.Skip(1).First();
            var lowHPMonster = Monsters.Where(p => p.CurrentHP < 20).First();
            var highStrMonster = Monsters.Where(p => p.Strength >= 11).First();
            var randomMonster = Monsters.ElementAt(new Random().Next(0, Monsters.Count()));
            if (Monster == null)
            {
                Monster = randomMonster;
            }
            Console.WriteLine("You've encountered a " + Monster.Name + "! " + Monster.Strength + " Strength/" + Monster.Defense + " Defense/" + 
            Monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1" || input == "") {
                this.HeroTurn();
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(){
           var compare = hero.Strength - Monster.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               Monster.CurrentHP -= damage;
           }
           else{
               damage = compare;
               Monster.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(Monster.CurrentHP <= 0){
               this.Win();
           }
           else
           {
               this.MonsterTurn();
           }
           
        }
        
        public void MonsterTurn(){
           int damage;
           var compare = Monster.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(Monster.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win() {
            Console.WriteLine(Monster.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}