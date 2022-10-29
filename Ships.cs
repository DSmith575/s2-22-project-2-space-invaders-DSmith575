﻿using System;
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


        public Ships(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
        {
            this.bitmap = bitmap;
            this.graphics = graphics;
            this.isAlive = isAlive;
            this.position = position;
            this.width = width;
            this.height = height;
        }


        public void DrawPlayer()
        {
            if (isAlive == true)
            {
                graphics.DrawImage(bitmap, position);
            }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { width = value; }
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


    }
}
