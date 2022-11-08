using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class AlienBomb : Weapon
    {
        public AlienBomb(Bitmap bmp, Graphics graphics, Point position, int width, int height, int lifeLimit) : base(bmp, graphics, position, width, height, lifeLimit)
        {
        }
    }
}
