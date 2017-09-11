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
                else
                {
                    return "Joker";
                }
            }
        }
        public int val;
        public string suit;
        public Card(string cardSuit, int numVal){
            suit = cardSuit;
            val = numVal;
        }

        public override string ToString() {
            return stringVal + " of " + suit;
        }
    }
    public class Deck
    {
        private List<Card> cards;
        
        public Deck() {
            Reset();
        }

        public Card Deal() {
            if(cards.Count > 0) {
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }
            return null;
        }

        public Deck Shuffle() {
            Random rand = new Random();
            for (int idx = cards.Count -1; idx > 0; idx--) {
                int randIdx = rand.Next(idx);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[idx];
                cards[idx] = temp;
            }
            return this;
        }

        public Deck Reset() {
            cards = new List<Card>();
            string[] suits = new string[4] {"Hearts", "Diamonds", "Clubs", "Spades"};
            foreach (string suit in suits) {
                for(int val = 1; val <= 13; val++) {
                    cards.Add(new Card(suit, val));
                }
            }
            return this;
        }

        public override string ToString() {
            string info = "";
            foreach (Card card in cards) {
                info += card + "\n";
            }
            return info;
        }
    }

    public class Player {
        public string name;
        private List<Card> hand;
        
        public Player(string newName) {
            hand = new List<Card>();
            name = newName;
        }

        public void Draw(Deck currentDeck) {
            hand.Add(currentDeck.Deal());
        }

        public Card Discard(int handIdx) {
            Card temp = hand[handIdx];
            hand.RemoveAt(handIdx);
            return temp;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
        }
    }
}
