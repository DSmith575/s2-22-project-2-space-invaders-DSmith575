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
        private bool movement = false;

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
                fleet.DrawShips();
            }
        }


        public void Movement()
        {

            if (alienShips[0].Position.X <= 0)
            {
                foreach (AlienShip fleet in alienShips)
                {
                    fleet.ShiftDown(DROPPOSY);
                    movement = true;
                }
            }

            if (alienShips[alienShips.Count - 1].Position.X + alienShips[alienShips.Count - 1].Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                foreach (AlienShip fleet in alienShips)
                {
                    fleet.ShiftDown(DROPPOSY);
                    movement = false;
                }
            }
            {
                if (movement == false)
                {
                    foreach(AlienShip fleet in alienShips)
                    {
                        fleet.MoveLeft();
                    }
                }
                if (movement == true)
                    foreach (AlienShip fleet in alienShips)
                    {
                        fleet.MoveRight();
                    }
            }


        }


//                    foreach (AlienShip fleet in alienShips)
//            {
//                if (alienShips[0].Position.X <= 0)
//                {
//                    fleet.ShiftDown(DROPPOSY);
//                    movement = true;
//                }
//                if (alienShips[alienShips.Count - 1].Position.X + alienShips[alienShips.Count - 1].Width >= Screen.PrimaryScreen.Bounds.Width)
//                {

//                    fleet.ShiftDown(DROPPOSY);
//                    movement = false;

//                }

//if (movement == false)
//{

//    fleet.MoveLeft();

//}
//if (movement == true)
//{

//    fleet.MoveRight();
//}
//            }



    }
}
        