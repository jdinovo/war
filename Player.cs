using System;
namespace War {
    public class Player {
        public int Number { get; set; }
        public int Points { get; set; }
        public int StackTop { get; set; }
        public Card Card { get; set; }

        public Player(int number, int stackTop) {
            this.Number = number;
            this.StackTop = stackTop;
            this.Points = 0;
            this.Card = new Card(0, "", Suit.Clubs);
        }

        public static bool operator >(Player lhs, Player rhs) {
            if (ReferenceEquals(lhs, null)) {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Points > rhs.Points;
        }

        public static bool operator <(Player lhs, Player rhs) {
            if (ReferenceEquals(lhs, null)) {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Points < rhs.Points;
        }

        public static bool operator ==(Player lhs, Player rhs) {
            if (ReferenceEquals(lhs, null)) {
                return ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Player lhs, Player rhs) {
            return !(lhs == rhs);
        }

        public override bool Equals(Object obj) {
            Player player = obj as Player;
            if (player != null) {
                return this.Points.Equals(player.Points);
            }
            return false;
        }
    }
}
