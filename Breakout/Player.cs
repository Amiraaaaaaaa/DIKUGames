using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Input;
using DIKUArcade.Math;
using System.IO;

namespace Breakout {
    public class Player : Entity {
        private readonly float screenWidth;
        private readonly float moveSpeed = 0.1f;

        public Player(float screenWidth, float screenHeight, IBaseImage image) 
            : base(new StationaryShape(InitialPosition(screenWidth, screenHeight), InitialExtent(), image)) {
            this.screenWidth = screenWidth;

            // Subscribe to keyboard event
            DIKUArcade.Window.EventBus.Subscribe(KeyboardEvent.KeyPressed, KeyPressed);
        }

        private static Vec2F InitialPosition(float screenWidth, float screenHeight) {
            // Calculating initial position of player
            float playerWidth = 64.0f;
            float playerHeight = 32.0f; 
            
            float playerX = (screenWidth - playerWidth) / 2.0f;
            float playerY = screenHeight / 3.0f;

            return new Vec2F(playerX, playerY);
        }

        private static Vec2F InitialExtent() {
            // Set the initial size of the player entity
            float playerWidth = 64.0f;
            float playerHeight = 32.0f;

            return new Vec2F(playerWidth, playerHeight);
        }

        private void KeyPressed(KeyboardEvent keyEvent) {
            // Checking keys pressed
            if (keyEvent.Key == Key.Left || keyEvent.Key == Key.A) {
                MoveLeft();
            } else if (keyEvent.Key == Key.Right || keyEvent.Key == Key.D) {
                MoveRight();
            }
        }

        public void MoveLeft() {
            // Calculating new position after moving left
            float newX = Shape.Position.X - moveSpeed;
            
            // Checking new position is within boundary of window
            if (newX >= 0) {
                // Move player to the left
                Shape.MoveX(-moveSpeed);
            }
        }

        public void MoveRight() {
            // Calculating the new position after moving right
            float playerWidth = Shape.Extent.X;
            float newX = Shape.Position.X + moveSpeed + playerWidth;

            // Checking if new position is within the boundary of window
            if (newX <= screenWidth) {
                // Move player to the right
                Shape.MoveX(moveSpeed);
            }
        }

        // Dispose method to unsubscribe from the keyboard event
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if (disposing) {
                DIKUArcade.Window.EventBus.Unsubscribe(KeyboardEvent.KeyPressed, KeyPressed);
            }
        }
    }
}
