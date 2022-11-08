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
        private const int DROPPOSY = 20;

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

        public List<AlienShip> AlienShips { get => alienShips; set => alienShips = value; }

        public void DrawFleet()
        {
            foreach (AlienShip fleet in alienShips)
            {
                fleet.DrawAlien();
            }
        }


        public void Movement()
        {
            foreach (AlienShip fleet in alienShips)
            {
            //if (alienShips[0].Position.X <= 0)
            //{
            //        fleet.ShiftDown(DROPPOSY);
            //}
            //if (alienShips[alienShips.Count - 1].Position.X + alienShips[alienShips.Count - 1].Width >= Screen.PrimaryScreen.Bounds.Width)
            //{
            //        fleet.ShiftDown(DROPPOSY);
            //}
                fleet.Move();
            }



            //if (alienShips[0].Position.X < Screen.PrimaryScreen.Bounds.Width - alienShips[0].Width)
            //{
            //    alienShips[i].Movement(false); //RIGHT
            //    //alienShips[i].ShiftDown(VELOCITY);
            //}
            //if (alienShips[alienShips.Count - 1].Position.X >= Screen.PrimaryScreen.Bounds.Width + alienShips[alienShips.Count -1].Width)
            //{
            //    //alienShips[i].ShiftDown(VELOCITY);
            //    alienShips[i].Movement(true); //LEFT
            //}

            //for (int j = 0; j < alienShips.Count; j++)
            //{
            //    alienShips[i].Move();
            //}

        }
    }
}
