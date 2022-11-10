using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class BombList
    {
        private Bitmap bmp;
        private List<AlienBomb> alienBombs;

        public List<AlienBomb> AlienBombs { get => alienBombs; set => alienBombs = value; }

        public BombList(Graphics graphics)
        {
            alienBombs = new List<AlienBomb>();
            bmp = Properties.Resources.EnemyShip;
        }


    }
}
