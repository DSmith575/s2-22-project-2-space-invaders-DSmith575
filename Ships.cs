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
        protected bool isAlive;
        protected Point position;


        protected int width;
        protected int height;

        //Main class for holding player and alien variables.

        public Ships(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
        {
            this.bitmap = bitmap;
            this.graphics = graphics;
            this.isAlive = isAlive;
            this.position = position;
            this.width = width;
            this.height = height;

        }


        //If the player/alien bool is true, draws the player to the screen
        //Do not currently need an alive checking bool.
        public void DrawShips()
        {
            //if (isAlive == true)
            //{
            graphics.DrawImage(bitmap, position);
            //}
        }



        //Gets/Sets position and bool status
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public bool Alive
        {
            get { return isAlive; }
            set { isAlive = value; }
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
