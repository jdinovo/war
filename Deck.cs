using System;
namespace War {
    public class Deck {
        public Card[] Cards { get; } = { new Card(1, "2", Suit.Clubs), new Card(1, "2", Suit.Hearts), new Card(1, "2", Suit.Diamonds), new Card(1, "2", Suit.Spades),
        new Card(2, "3", Suit.Clubs), new Card(2, "3", Suit.Hearts), new Card(2, "3", Suit.Diamonds), new Card(2, "3", Suit.Spades),
        new Card(3, "4", Suit.Clubs), new Card(3, "4", Suit.Hearts), new Card(3, "4", Suit.Diamonds), new Card(3, "4", Suit.Spades),
        new Card(4, "5", Suit.Clubs), new Card(4, "5", Suit.Hearts), new Card(4, "5", Suit.Diamonds), new Card(4, "5", Suit.Spades),
        new Card(5, "6", Suit.Clubs), new Card(5, "6", Suit.Hearts), new Card(5, "6", Suit.Diamonds), new Card(5, "6", Suit.Spades),
        new Card(6, "7", Suit.Clubs), new Card(6, "7", Suit.Hearts), new Card(6, "7", Suit.Diamonds), new Card(6, "7", Suit.Spades),
        new Card(7, "8", Suit.Clubs), new Card(7, "8", Suit.Hearts), new Card(7, "8", Suit.Diamonds), new Card(7, "8", Suit.Spades),
        new Card(8, "9", Suit.Clubs), new Card(8, "9", Suit.Hearts), new Card(8, "9", Suit.Diamonds), new Card(8, "9", Suit.Spades),
        new Card(9, "10", Suit.Clubs), new Card(9, "10", Suit.Hearts), new Card(9, "10", Suit.Diamonds), new Card(9, "10", Suit.Spades),
        new Card(10, "J", Suit.Clubs), new Card(10, "J", Suit.Hearts), new Card(10, "J", Suit.Diamonds), new Card(10, "J", Suit.Spades),
        new Card(11, "Q", Suit.Clubs), new Card(11, "Q", Suit.Hearts), new Card(11, "Q", Suit.Diamonds), new Card(11, "Q", Suit.Spades),
        new Card(12, "K", Suit.Clubs), new Card(12, "K", Suit.Hearts), new Card(12, "K", Suit.Diamonds), new Card(12, "K", Suit.Spades),
        new Card(13, "A", Suit.Clubs), new Card(13, "A", Suit.Hearts), new Card(13, "A", Suit.Diamonds), new Card(13, "A", Suit.Spades)};

        public void Shuffle() {
            Console.WriteLine("Shuffling Deck...\n");
            Card holder;
            for (int i = 0; i < this.Cards.Length; i++) {
                int r = new Random().Next(0, Cards.Length);
                holder = this.Cards[i];
                this.Cards[i] = this.Cards[r];
                this.Cards[r] = holder;
            }
        }

        public void GetPlayerCards(ref Player p1, ref Player p2) {
            if (!Empty(p1, p2)) {
                p1.Card = Cards[p1.StackTop];
                p2.Card = Cards[p2.StackTop];
            }
            p1.StackTop++;
            p2.StackTop++;
        }

        public Boolean Empty(Player p1, Player p2) {
            if (p1 != null && p2 != null) {
                if (p1.StackTop < 26 && p2.StackTop < Cards.Length) {
                    return false;
                }
            }
            return true;
        }
    }
}
