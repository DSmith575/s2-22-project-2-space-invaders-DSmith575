using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public abstract class Weapon
    {

        protected const int VELOCITY = 20;
        protected Bitmap bmp;
        protected Graphics graphics;
        protected Point position;
        protected int width;
        protected int height;
        protected int lifeLimit;


        public Weapon(Bitmap bmp, Graphics graphics, Point position, int width, int height, int lifeLimit)
        {
            this.bmp = bmp;
            this.graphics = graphics;
            this.position = position;
            this.width = width;
            this.height = height;
            this.lifeLimit = lifeLimit;
        }


        public void DrawMissile()
        {
            graphics.DrawImage(bmp, position);
        }

        public void MissileMovement()
        {
            this.position.Y -= VELOCITY;
        }

        public void BombMovement()
        {
            this.position.Y += VELOCITY;
        }


        public int LifeLimit
        {
            get => lifeLimit;
            set => lifeLimit = value;
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }

        }

        public Rectangle rect()
        {
            return new Rectangle(position.X, position.Y, width, height);
        }

    }
}
