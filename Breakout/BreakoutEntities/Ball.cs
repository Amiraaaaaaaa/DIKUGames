using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Physics;

namespace Breakout.Entities {
    public class Ball: Entity{

        // private IBaseImage altImage;
        private const float MOVEMENT_SPEED =0.02f;
        
         /// <summary>
        /// Initializes a new instance of the Ball class.
        /// </summary>
        /// <param name="shape">The dynamic shape of the ball.</param>
        /// <param name="image">The image representing the ball.</param>
        public Ball(DynamicShape shape, IBaseImage image) : base(shape, image) {
            this.Shape.AsDynamicShape().ChangeDirection(new Vec2F(0.02f, 0.02f));
        }

        //forbunder bollden med miden af palyer og skulder bolden.
        public void ResetBall(Player player){
            this.Shape.Position.X = player.Shape.Position.X + player.Shape.Extent.X/2;
            this.Shape.Position.Y = player.Shape.Position.Y + player.Shape.Extent.Y;
            this.Shape.AsDynamicShape().ChangeDirection(new Vec2F(0.02f, 0.02f));
        }



        /// <summary>
        /// Moves the ball in the game area considering collisions with the blocks, player, 
        /// and the game frame.
        /// </summary>
        /// <param name="blockDict">A dictionary of blocks in the game, where the key is a pair of 
        /// integers representing the position of the block 
        /// and the value is the block itself.</param>
        /// <param name="player">The player in the game.</param>
        public void MoveBall(Dictionary<(int, int), Block> blockDict, Player player){
            
            if (this.Shape.Position.X + this.Shape.Extent.X >= 1.0f) {//findse x-kordinaten af bolleden siker at den bliver inden i skammet 
                this.Shape.AsDynamicShape().ChangeDirection(new Vec2F
                (-MOVEMENT_SPEED, this.Shape.AsDynamicShape().Direction.Y));

            }
            if (this.Shape.Position.Y + this.Shape.Extent.Y>= 1.0f) {//fornde y-kordinatten
                this.Shape.AsDynamicShape().ChangeDirection(new Vec2F
                (this.Shape.AsDynamicShape().Direction.X, -MOVEMENT_SPEED));
            }
            if (this.Shape.Position.X - (MOVEMENT_SPEED /2 ) <=0){
                this.Shape.AsDynamicShape().ChangeDirection(new Vec2F
                (MOVEMENT_SPEED, this.Shape.AsDynamicShape().Direction.Y));
                

            }
            CollisionDetector(blockDict, player);


            if (this.Shape.Position.Y < 0) {
                //this.DeleteEntity();
                ResetBall(player);
                return;
            }
           
             
            
            Shape.Move();
        }
        public bool HandleCollision(DynamicShape otherShape){
            var collisionResult = CollisionDetection.Aabb(this.Shape.AsDynamicShape(), otherShape);
            if ((CollisionDetection.Aabb(this.Shape.AsDynamicShape(), otherShape).CollisionDir)//finde ud af at der collition
                    == CollisionDirection.CollisionDirLeft ||
                    (CollisionDetection.Aabb(this.Shape.AsDynamicShape(), otherShape).CollisionDir)
                    == CollisionDirection.CollisionDirRight){
                this.Shape.AsDynamicShape().ChangeDirection(new Vec2F(
                -this.Shape.AsDynamicShape().Direction.X,
                this.Shape.AsDynamicShape().Direction.Y));
                return true;
                        
            }else if (collisionResult.CollisionDir == CollisionDirection.CollisionDirUp ||
            collisionResult.CollisionDir == CollisionDirection.CollisionDirDown){
            // else if ((CollisionDetection.Aabb(this.Shape.AsDynamicShape(), otherShape)
            //         .CollisionDir)== CollisionDirection.CollisionDirUp ||
            //         (CollisionDetection.Aabb(this.Shape.AsDynamicShape(), otherShape).CollisionDir)
            //         == CollisionDirection.CollisionDirDown){
                this.Shape.AsDynamicShape().ChangeDirection(new Vec2F(
                this.Shape.AsDynamicShape().Direction.X,
                -this.Shape.AsDynamicShape().Direction.Y));
                return true;    
                        

            }
            return false; 
        }

        private void CollisionDetector(Dictionary<(int, int), Block> blockDict, Player player){
            HandleCollision(player.Shape.AsDynamicShape());
            foreach (var block in blockDict.Values){
                if (HandleCollision(block.Shape.AsDynamicShape())){
                    block.TakeHit();
                }
            }

        }


    }
}
