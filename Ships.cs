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
        protected Point boundries;
        protected Point position;


        public Ships(Bitmap bitmap, Graphics graphics, bool isAlive, Point boundries, Point position)
        {
            this.bitmap = bitmap;
            this.graphics = graphics;
            this.isAlive = isAlive;
            this.boundries = boundries;
            this.position = position;
        }


        public void DrawPlayer()
        {
            if (isAlive == true)
            {
                graphics.DrawImage(bitmap, position);
            }
        }

        public Graphics Graphics
        {
            get { return graphics; }
            set { graphics = value; }
        }

        public Point Boundries
        {
            get { return boundries; }
            set { boundries = value; }
        }

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

        public Bitmap Image
        {
            get { return bitmap; }
            set { bitmap = value; }
        }




    }
}
