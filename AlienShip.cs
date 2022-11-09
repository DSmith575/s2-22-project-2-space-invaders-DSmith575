﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class AlienShip : Ships
    {

        private const int VELOCITY = 20;

        public AlienShip(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
            : base(bitmap, graphics, isAlive, position, width, height)
        {
            this.width = width;
        }


        public void ShiftDown(int velocity)
        {
            position.Y += velocity;
        }

        public void MoveLeft()
        {
            position.X -= VELOCITY;

        }

        public void MoveRight()
        {
            position.X += VELOCITY;

        }


        public override void Move()
        {
        }

    }
}
