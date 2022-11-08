using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class AlienShip : Ships
    {

        private AlienFleet fleet;

        private const int VELOCITY = 100;
        private bool movement = false;
        private const int DROPSPEED = 25;

        public AlienShip(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
            : base(bitmap, graphics, isAlive, position, width, height)
        {
            this.width = width;
        }






        public void ShiftDown(int velocity)
        {
            position.Y += velocity;
        }
        public override void Move()
        {
            switch (movement)
            {
                case false:
                    if (position.X < Screen.PrimaryScreen.Bounds.Width - width)
                    {
                        position.X += VELOCITY;
                    }
                    if (position.X >= Screen.PrimaryScreen.Bounds.Width - width)
                    {
                        movement = true;
                        //position.Y += DROPSPEED;
                    }
                    break;

                case true:
                    if (position.X != 0)
                    {
                        position.X -= VELOCITY;
                        if (position.X == 0)
                        {
                            movement = false;
                            //position.Y += DROPSPEED;
                        }
                    }
                    break;

                default:
                    break;

            }

        }

    }
}
