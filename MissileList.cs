using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    public class MissileList
    {
        private const int MAXONSCREEN = 15;
        private const int VELOCITY = 10;

        private Bitmap bmp;

        private List<PlayerMissile> playerMissiles;

        public List<PlayerMissile> PlayerMissiles { get => playerMissiles; set => playerMissiles = value; }

        public MissileList(Graphics graphics)
        {
            playerMissiles = new List<PlayerMissile>();
            bmp = Properties.Resources.EnemyShip;
        }

        public void SpawnMissile(Graphics graphics, Point velocity, int lifeLimit)
        {
            if (playerMissiles.Count <= MAXONSCREEN)
            {
                playerMissiles.Add(new PlayerMissile(bmp, graphics, true, new Point(velocity.X, velocity.Y), bmp.Width, bmp.Height, lifeLimit));
            }
        }

        public void DrawM()
        {
            foreach (PlayerMissile missile in playerMissiles)
            {
                missile.DrawMissile();
            }
        }

        public void MoveMissile()
        {
            for (int i = 0; i < playerMissiles.Count; i++)
            {
                playerMissiles[i].MissileMovement();
                playerMissiles[i].LifeLimit--; //Lowers lifespan by timer tick
            }
        }

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
