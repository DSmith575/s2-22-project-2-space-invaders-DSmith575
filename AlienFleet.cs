using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class AlienFleet
    {
        private const int GAP = 40;
        private const int ROWS = 4;
        private const int COLS = 10;
        private const int DROPYPOS = 25;
        private const int VELOCITY = 20;


        private Graphics graphics;
        private Bitmap alienS;
        private List<AlienShip> alienShips;

        public AlienFleet(Graphics graphics)
        {
            this.graphics = graphics;
            alienS = Properties.Resources.EnemyShip;
            alienShips = new List<AlienShip>();

            for (int i = 0; i < COLS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    alienShips.Add(new AlienShip(alienS, graphics, true, new Point(i * GAP, j * GAP), alienS.Width, alienS.Height));
                }
            }
        }


        public void DrawFleet()
        {
            foreach (AlienShip fleet in alienShips)
            {
                fleet.DrawAlien();
            }
        }


        public void Movement()
        {
            foreach(AlienShip ship in alienShips)
            {
                ship.Move();
            }
        }



    }
}
