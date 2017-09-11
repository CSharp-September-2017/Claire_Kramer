using System;
using System.Collections.Generic;

namespace cards
{
    public class Card 
    {
        public string stringVal {
            get {
                if(val > 1 && val < 11) 
                {
                    return val.ToString();
                }
                else if (val == 11)
                {
                    return "Jack";
                }
                else if (val == 12)
                {
                    return "Queen";
                }
                else if (val == 13)
                {
                    return "King";
                }
                else if (val == 1)
                {
                    return "Ace";
                }
            }
        }
        public int val;
        public string suit;
        public Card(string cardSuit, int numVal){
            suit = cardSuit;
            val = numVal;
        }
        public override string ToString(){
            return stringVal + " of " + suit;
        }
    }
    public class Deck
    {
        public List<object> cards;
        public Deck()
        {
            car
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
