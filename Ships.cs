using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public abstract class Ships
    {
        protected Bitmap bitmap;
        protected Graphics graphics;
        protected Point position;

        protected int width;
        protected int height;
        protected bool canShoot;

        //Main class for holding player and alien variables.
        public Ships(Bitmap bitmap, Graphics graphics, bool canShoot, Point position, int width, int height)
        {
            this.bitmap = bitmap;
            this.graphics = graphics;
            this.canShoot = canShoot;
            this.position = position;
            this.width = width;
            this.height = height;
        }


        //If the player/alien bool is true, draws the player to the screen
        //Do not currently need an alive checking bool.
        public void DrawShips()
        {
            graphics.DrawImage(bitmap, position);
        }



        //Gets/Sets position and bool status
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool CanShoot
        {
            get { return canShoot; }
            set { canShoot = value; }
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


        public abstract void Move();


    }
}
