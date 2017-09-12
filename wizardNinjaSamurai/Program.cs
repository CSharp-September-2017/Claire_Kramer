using System;
using System.Collections.Generic;

namespace wizardNinjaSamurai
{
    public class Human {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }

        public Human(string person)
        {
            name = person;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }
        public Human(string person, int str, int intel, int dex, int hp)
        {
            name = person;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
        public void attack(object victim)
        {
            Human enemy = victim as Human;
            if(enemy == null)
            {
                Console.WriteLine("Failed Attack");
            }
            else
            {
                int damage = strength * 5;
                enemy.health -= damage;
                Console.WriteLine("{0} atttacked {1} and did {2} damage.", name, enemy.name, damage);
            }
        }
    }

    public class Wizard : Human {
        public Wizard() : base("Wizard") {
            health = 50;
            intelligence = 25;
        }

        public void Heal() {
            health += 10 * intelligence;
        }

        public void Fireball(object victim) {
            Human enemy = victim as Human;
            Random rand = new Random();
            int damage = rand.Next(20, 50);
            enemy.health -= damage;
            Console.WriteLine("{0} atttacked {1} and did {2} damage.", name, enemy.name, damage);
        }
    }

    public class Ninja : Human {
        public Ninja() : base("Ninja") {
            dexterity = 175;
        }

        public void Steal(object victim) {
            Human enemy = victim as Human;
            enemy.health -= 10;
            health += 10;
            Console.WriteLine("{0} stole 10 HP from {1}", name, enemy.name);
        }

        public void GetAway() {
            health -= 15;
            Console.WriteLine("{0} got away!", name);
        }
    }

    public class Samurai : Human {
        public Samurai() : base("Samurai") {
            health = 200;
        }
        public void DeathBlow(object victim) {
            Human enemy = victim as Human;
            if (enemy.health < 50) {
                enemy.health = 0;
                Console.WriteLine("{0} delievered a Death Blow to {1}", name, enemy.name);
            }
            else {
                Console.WriteLine("Enemy has too much HP to Deliever Dealth Blow");
            }
        }
        public void Meditate() {
            health = 200;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
