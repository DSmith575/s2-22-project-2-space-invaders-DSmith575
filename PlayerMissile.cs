using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class PlayerMissile : Weapon
    {
        public PlayerMissile(Bitmap bmp, Graphics graphics, bool isAlive, Point position, int width, int height, int lifeLimit) 
            : base(bmp, graphics, isAlive, position, width, height, lifeLimit)
        {

        }

    }
}
