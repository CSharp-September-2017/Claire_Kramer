using System;

namespace human
{
    public class Human 
    {
        public string name;
        public Human(string newName)
        {
            name = newName;
        }
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public Human(string newName, int newStrength, int newIntell, int newDex, int newHealth)
        {
            name = newName;
            strength = newStrength;
            intelligence = newIntell;
            dexterity = newDex;
            health = newHealth;
        }
        public void Attack(object victim)
        {
            Human enemy = victim as Human;
            int damage = 5 * strength;
            enemy.health -= damage;
            Console.WriteLine("{0} attacked and did {1} damage to {2}", name, damage, enemy.name);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Human batman = new Human("Batman");
            Human catwoman = new Human("Cat Woman");
            batman.Attack(catwoman);
        }
    }
}
