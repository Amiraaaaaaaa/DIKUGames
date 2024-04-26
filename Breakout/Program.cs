using System.IO;
using DIKUArcade;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            // Initialize game window
            var windowArgs = new WindowArgs() { Title = "Breakout v1.0" };
            var game = new Game(windowArgs);

            // Load player images
            var playerImage = new Image(Path.Combine("assets", "Player.png"));

            // Get dimensions of the game window
            float screenWidth = game.GetWindow().Width;
            float screenHeight = game.GetWindow().Height;

            // Create player entity
            var player = new Player(screenWidth, screenHeight, playerImage);

            // Add player entity to game
            game.AddEntity(player);

            // Subscribe to the keyboard event
            DIKUArcade.Window.EventBus.Subscribe(KeyboardEvent.KeyPressed, KeyPressed);

            game.Run();
        }

        private static void KeyPressed(KeyboardEvent keyEvent) {
            // Get game instance
            var game = Game.GetGameInstance();

            // Get player entity from the game
            var player = game.Entities.Get<Player>();

            // Check if player entity exists
            if (player != null) {
                // Check keys pressed
                if (keyEvent.Key == Key.Left || keyEvent.Key == Key.A) {
                    player.MoveLeft();
                } else if (keyEvent.Key == Key.Right || keyEvent.Key == Key.D) {
                    player.MoveRight();
                }
            }
        }
    }
}
