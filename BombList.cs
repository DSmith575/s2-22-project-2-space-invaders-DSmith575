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
        private Graphics graphics;
        private const int BOMBLIFE = 10;
        private List<AlienBomb> alienBombs;
        private List<AlienShip> alienShips;
        private Random rand;

        public List<AlienBomb> AlienBombs { get => alienBombs; set => alienBombs = value; }

        public BombList(Graphics graphics)
        {
            alienBombs = new List<AlienBomb>();
            bmp = Properties.Resources.EnemyShip;
        }


        //Method to add alien bombs to the list.
        
        
        //Change this velocity JFC
        public void SpawnBombs(Graphics graphics, Point position, int lifeLimit)
        {
            alienBombs.Add(new AlienBomb(bmp, graphics, new Point(position.X +2, position.Y +2), bmp.Width, bmp.Height, lifeLimit));
        }

        //Draws bombs on screen when called
        public void DrawB()
        {
            foreach(AlienBomb bomb in alienBombs)
            {
                bomb.DrawMissile();
            }
        }

        //Moves bombs on the Y axis every timer tick
        public void MoveBomb()
        {
            for (int i = 0; i < alienBombs.Count; i++)
            {
                alienBombs[i].BombMovement();
                alienBombs[i].LifeLimit--;
            }
        }

        //Checks the current int value of "life limit" or the position of each bomb.
        //int reduces each timer tick, and if reaches 0 removes that bomb from the list.
        //If the bomb hits the end of the screen (player area) bomb is also removed from the list.
        public void LifeCheckBomb()
        {
            for (int i = 0; i < alienBombs.Count; i++)
            {
                if ((alienBombs[i].LifeLimit == 0) || (alienBombs[i].Position.Y == Screen.PrimaryScreen.Bounds.Height))
                {
                    alienBombs.Remove(alienBombs[i]);
                }
            }
        }



    }
}
