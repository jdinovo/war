using System;
namespace War {
    public class Game {
        Player P1;
        Player P2;
        Deck deck;
        int Rounds;
        int[] Scores = new int[3];

        // Main run loop
        public void Run() {
            do {
                P1 = new Player(1, 0);
                P2 = new Player(2, 26);
                deck = new Deck();
                Rounds = 0;
                Welcome();
                deck.Shuffle();
                Play();
                Console.Write("Play Again? (Y/N):");
            } while (Console.ReadKey().Key == ConsoleKey.Y);

            Console.Write($"\nTotal wins - Player 1: {Scores[0]}\tPlayer 2: {Scores[1]}\tDraws: {Scores[2]}");

        }

        // Welcome display
        void Welcome() {
            Console.Clear();
            Console.WriteLine(new string('*', 31));
            Console.WriteLine("| Welcome to the game of WAR! |");
            Console.WriteLine(new string('*', 31) + "\n");
            Console.WriteLine("Press <enter> to begin...");
            Console.ReadLine();
        }

        // Main game loop
        void Play() {
            Boolean draw;
            int drawCounter;
            int pointCounter;

            // each round
            do {
                Rounds++;
                pointCounter = 0;
                deck.GetPlayerCards(ref P1, ref P2);
                pointCounter++;

                Console.WriteLine($"P1 Score: {P1.Points}\tP2 Score: {P2.Points}\nRound: {Rounds}");

                Console.WriteLine($"Player 1 plays: {P1.Card}\tPlayer 2 plays: {P2.Card}");
                // each draw
                do {
                    draw = CheckRoundOutcome(P1, P2, pointCounter);
                    if (draw) {
                        Console.WriteLine($"                   {new string('>', 9)}WAR{new string('<', 9)}");
                        drawCounter = 0;
                        while (drawCounter < 4 && !deck.Empty(P1, P2)) {
                            drawCounter++;
                            deck.GetPlayerCards(ref P1, ref P2);
                            pointCounter++;
                            Console.WriteLine($"                {P1.Card}\t                {P2.Card}");

                        }
                        draw = CheckRoundOutcome(P1, P2, pointCounter);
                    }
                } while (draw);
                Console.WriteLine("Press <enter> to continue...");
                Console.ReadLine();
            } while (!deck.Empty(P1, P2) && Rounds < 26);

            CheckGameOutcome(P1, P2);
        }

        // check outcome of game
        void CheckGameOutcome(Player p1, Player p2) {
            Console.WriteLine($"P1 Score: {P1.Points}\tP2 Score: {P2.Points}");
            if (p1 > p2) {
                Scores[0]++;
                Console.WriteLine("Congratulations Player 1, you've won!!!\n");
            } else if (p1 < p2) {
                Scores[1]++;
                Console.WriteLine("Congratulations Player 2, you've won!!!\n");
            } else {
                Scores[2]++;
                Console.WriteLine("This game is a draw!\n");
            }
        }

        // check outcome of round
        Boolean CheckRoundOutcome(Player p1, Player p2, int points) {

            if (p1.Card > p2.Card) {
                p1.Points += points;
                DisplayRoundWinner(p1, points);
            } else if (p1.Card < p2.Card) {
                p2.Points += points; 
                DisplayRoundWinner(p2, points);
            } else {
                if (deck.Empty(p1, p2)) {
                    Console.WriteLine("Draw! - No points awarded\n");
                    return false;
                }
                return true;
            }
            return false;
        }

        void DisplayRoundWinner(Player player, int points) {
            Console.WriteLine($"Player {player.Number} wins {points} point(s)!\n");
        }
    }
}
