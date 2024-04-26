using DIKUArcade.Graphics;
using DIKUArcade.Physics;
using System.IO;
using System.Collections.Generic;
using DIKUArcade.Math;
using System;
using DIKUArcade.Entities;
using Breakout.Entities;

namespace Breakout.Blocks {
    /// <summary>
    ///  The default block with no special propaties. All other blocks must inherate this block
    /// </summary>
    public class Block: Entity {
        private int hitpoints = 1;
        private DynamicShape shape;

        public Block(DynamicShape shape, IBaseImage image, int hitpoints) : base(shape, image) {
            this.hitpoints = hitpoints;
            this.shape = shape;
        }

        public DynamicShape getShape() {
            return shape;
        }

        public virtual bool getHasToBreak () {
            return true; 
        }

        public virtual PowerUp? spawnPowerUp() {
            return null;
        }

        public virtual void blockHit(){
            hitpoints -= 1;
        }

        public int getHitpoints(){
            return hitpoints;
        }

        public virtual void update () {
        }

        public bool blockDestoryed(){
            if (hitpoints <= 0){
                DeleteEntity();
                
                return true;
            } else
            {
                return false;
            }
        }
    }
}