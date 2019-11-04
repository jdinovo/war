using System;
namespace War {
    public class Card {
        public int Value { get; }
        public string Name { get; }
        public Suit Suit { get; }

        public Card(int value, string name, Suit suit) {
            this.Value = value;
            this.Name = name;
            this.Suit = suit;
        }

        public static bool operator >(Card lhs, Card rhs) {
            if (lhs is null) {
                return rhs is null;
            }
            return lhs.Value > rhs.Value;
        }

        public static bool operator <(Card lhs, Card rhs) {
            if(lhs is null) {
                return rhs is null;
            }
            return lhs.Value < rhs.Value;
        }

        public static bool operator ==(Card lhs, Card rhs) {
            if (lhs is null) {
                return rhs is null;
            }
            return lhs.Value == rhs.Value;
        }

        public static bool operator !=(Card lhs, Card rhs) {
            return !(lhs.Value == rhs.Value);
        }

        public override bool Equals(Object obj) {
            Card card = obj as Card;
            if (card != null) {
                return this.Value.Equals(card.Value);
            }
            return false;
        }


        public override string ToString() {
            switch (this.Suit) {
                case Suit.Hearts:
                    return Name + "\u2665";
                case Suit.Diamonds:
                    return Name + "\u2666";
                case Suit.Clubs:
                    return Name + "\u2663";
                case Suit.Spades:
                    return Name + "\u2660";
                default:
                    return Name;
            }
        }

    }

}
