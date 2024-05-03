

using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout {
    public class Player : Entity, IGameEventProcessor {
        
        private bool moveLeft = false;
        private bool moveRight = false;
        private float MOVEMENT_SPEED = 0.02f;
       
        //private int activeBalls;
        public Player(DynamicShape shape, IBaseImage image) : base(shape, image) {
        
        }

        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.PlayerEvent) {
                switch (gameEvent.Message) {
                    case "MOVE_LEFT":
                        moveLeft = true;
                        break;
                    case "MOVE_RIGHT":
                        moveRight = true;
                        break;
                    
                    case "STOP_MOVE":
                        moveLeft= false;
                        moveRight= false;
                        break;
                    case "PLAYER_SIZE_POWERUP":
                        if (gameEvent.StringArg1 == "increase") {
                            this.Shape.Position.X = this.Shape.Position.X - 0.05f;
                            this.Shape.Extent.X = this.Shape.Extent.X + 0.1f;
                        }
                        else {
                            this.Shape.Position.X = this.Shape.Position.X + 0.05f;
                            this.Shape.Extent.X = this.Shape.Extent.X - 0.1f;
                        }
                        break;
                    case "PLAYER_SPEED_POWERUP":
                        if (gameEvent.StringArg1 == "increase") {
                            MOVEMENT_SPEED += 0.02f;
                        }
                        else {
                            MOVEMENT_SPEED -= 0.02f;
                        }
                        break;
                    }
                }
            }
        

        public void Move() {
            if (moveLeft && moveRight) {
            } else if (moveLeft) {
                if (this.Shape.Position.X - (MOVEMENT_SPEED / 60) >= 0) {
                    this.Shape.MoveX(-MOVEMENT_SPEED);
                } else if (this.Shape.Position.X < 0) {
                    this.Shape.Position.X = 0;
                }
            } else if (moveRight) {
                if (this.Shape.Position.X + this.Shape.Extent.X + MOVEMENT_SPEED <= 1) {
                    this.Shape.MoveX(MOVEMENT_SPEED);
                }
            }
        }
        
    }

}