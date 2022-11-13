using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class MissileList
    {
        private const int MAXONSCREEN = 15; //Maximum amount of missiles allowed on screen

        private Bitmap bmp;
        private List<PlayerMissile> playerMissiles;
        public List<PlayerMissile> PlayerMissiles { get => playerMissiles; set => playerMissiles = value; }

        public MissileList(Graphics graphics)
        {
            playerMissiles = new List<PlayerMissile>();
            bmp = Properties.Resources.EnemyShip;
        }


        //Method to add missiles to list so we can check and remove them when needed
        public void SpawnMissile(Graphics graphics, Point position, int lifeLimit)
        {
            if (playerMissiles.Count <= MAXONSCREEN)
            {
                playerMissiles.Add(new PlayerMissile(bmp, graphics, new Point(position.X, position.Y), bmp.Width, bmp.Height, lifeLimit));
            }
        }

        //Method to draw missiles.
        public void DrawM()
        {
            foreach (PlayerMissile missile in playerMissiles)
            {
                missile.DrawMissile();
            }
        }

        //Method to move player spawned missiles, moves in the Y direction and each timer tick lowers the lifespan variable.
        public void MoveMissile()
        {
            for (int i = 0; i < playerMissiles.Count; i++)
            {
                playerMissiles[i].MissileMovement();
                playerMissiles[i].LifeLimit--; //Lowers lifespan by timer tick
            }
        }


        //Method to check current lifelimit of each spawned missile, if the missile lifelimit is 0 or equal to 0, removes the missile from the list
        public void LifeCheck()
        {
            for (int i = 0; i < playerMissiles.Count; i++)
            {
                if ((playerMissiles[i].LifeLimit) == 0 || (playerMissiles[i].Position.Y == 0))
                {
                    playerMissiles.Remove(playerMissiles[i]);
                }
            }
        }





    }
}
