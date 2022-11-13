using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Space_Invaders
{
    public class AlienFleet
    {
        private const int GAP = 40;
        private const int ROWS = 4;
        private const int COLS = 10;
        private const int DROPPOSY = 50;

        private Graphics graphics;
        private Bitmap alienS;
        private List<AlienShip> alienShips;

        private bool movement = false;


        public List<AlienShip> AlienShips { get => alienShips; set => alienShips = value; }

        public AlienFleet(Graphics graphics)
        {
            this.graphics = graphics;
            alienS = Properties.Resources.EnemyShip;
            alienShips = new List<AlienShip>();

            for (int i = 0; i < COLS; i++)
            {
                for (int j = 0; j < ROWS; j++)
                {
                    //If J is equal to 3 adds an alien ship with the alive bool of true, this allows it to be able to drop a bomb, if not equal to three
                    //Creates a ship with the bool set to false.
                    if (j == 3)
                    {
                        alienShips.Add(new AlienShip(alienS, graphics, true, new Point(i * GAP, j * GAP), alienS.Width, alienS.Height));
                    }
                    else
                    {
                        alienShips.Add(new AlienShip(alienS, graphics, false, new Point(i * GAP, j * GAP), alienS.Width, alienS.Height));
                    }
                }
            }
        }


        //Draws each fleet
        public void DrawFleet()
        {
            foreach (AlienShip fleet in alienShips)
            {
                fleet.DrawShips();
            }
        }

        public void Movement()
        {
            //If the first alien in list position 0 is less than or equal to 0 (Boundry of left screen)
            //Will drop every alien ship down the Y Axis and switchs a bool to true to make the fleet move to the other side of the screen
            if (alienShips[0].Position.X <= 0)
            {
                foreach (AlienShip fleet in alienShips)
                {
                    fleet.ShiftDown(DROPPOSY);
                    movement = true;
                }
            }

            //Checks if the last position -1 (0-39) +plus the aliens image width is greater than or equal to the Width of the screen(Right Side)
            //Drops each alien down the Y axis and switches the bool to false, making the ships move to the left
            if (alienShips[alienShips.Count - 1].Position.X + alienShips[alienShips.Count - 1].Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                foreach (AlienShip fleet in alienShips)
                {
                    fleet.ShiftDown(DROPPOSY);
                    movement = false;
                }
            }


            //Checks current state of the movmenet bool variable and runs the appropriate movement method
            switch (movement)
            {
                case false:
                    foreach (AlienShip fleet in alienShips)
                    {
                        fleet.MoveLeft();
                    }
                    break;

                case true:
                    if (movement == true)
                        foreach (AlienShip fleet in alienShips)
                        {
                            fleet.MoveRight();
                        }
                    break;

                default:
                    break;
            }

        }
    }
}
