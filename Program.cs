using System;

namespace War {
    class MainClass {
        public static void Main(string[] args) {
            // set output encoding
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // create new game instance
            Game game = new Game();

            // run game
            game.Run();

        }
    }
        
}
