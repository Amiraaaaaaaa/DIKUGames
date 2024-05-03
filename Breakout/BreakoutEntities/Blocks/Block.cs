using DIKUArcade.Events;
using DIKUArcade.Entities;
using DIKUArcade.Graphics;

namespace Breakout.Entities {
    public class Block : Entity {
        private int health;
        public int Health { get { return health; } }
        public int? Value;
        private IBaseImage altImage;

        public Block(Shape shape, IBaseImage img, IBaseImage altImg, int hp) : base(shape, img) {
            this.health = hp;
            this.altImage = altImg;
        }

    

        public void TakeHit() {
            this.health--;
            this.Image = altImage;

            if (health <= 0) {
                this.DeleteEntity();
            }
        }
    }
}