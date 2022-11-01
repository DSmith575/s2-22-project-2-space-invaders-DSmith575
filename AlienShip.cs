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

        private const int DROPSPEED = 20;
        private const int DIRECTSHIFT = -1;
        private int velocity = 20;

        public AlienShip(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
            : base(bitmap, graphics, isAlive, position, width, height)
        {
        }


        public override void Move()
        {
            if (position.X > 0)
            {
                position.X -= 20;
            }
            if (position.X <= Screen.PrimaryScreen.Bounds.Width - height)
            {
                position.X += 20;
            }
        }

        public void ShiftDown(int velocity)
        {
            position.Y += velocity;
        }
    }
}
