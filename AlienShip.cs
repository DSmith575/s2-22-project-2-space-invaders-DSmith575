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
        //Alien ships position movement speed
        private const int VELOCITY = 20;

        public AlienShip(Bitmap bitmap, Graphics graphics, bool isAlive, Point position, int width, int height)
            : base(bitmap, graphics, isAlive, position, width, height)
        {
            this.width = width;
        }

        //When the first or last ship touches the left or right sides
        //Calls this method to move every ship on screen down before moving to the other side
        public void ShiftDown(int velocity)
        {
            position.Y += velocity;
        }

        //Move moveLeft and MoveRight to MOvement(bool F/T)? Switch statement to call movement
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
